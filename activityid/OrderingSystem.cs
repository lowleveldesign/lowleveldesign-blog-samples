using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using Essential.Diagnostics;
using Dapper.Contrib.Extensions;

namespace LowLevelDesign.Samples 
{
    public sealed class Order 
    {
        public int Id { get; set; }
        
        public String Username { get; set; }
        
        public String Product { get; set; }
        
        public decimal Cash { get; set; }
        
        public Guid ActivityId { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        // OK or FAIL
        public String Status { get; set; }
        
        // Explanation about the status
        public String StatusMessage { get; set; }
    }

    public sealed class OrderingSystem 
    {
        private const int MaxStatusMessageLength = 2000;
        private static readonly TraceSource logger = new TraceSource("OrderingSystem");
    
        public int PlaceOrder(String username, String product, decimal cash) 
        {
            using (new ActivityScope(logger)) {
                // create an order record
                var order = new Order {
                                Username = username,
                                Product = product,
                                Cash = cash,
                                CreatedOn = DateTime.UtcNow,
                                ActivityId = Trace.CorrelationManager.ActivityId
                            };
            
                // validation: if order is invalid throw some exception - ask client to correct
                if (String.IsNullOrEmpty(username)) {
                    logger.TraceEvent(TraceEventType.Warning, 0, "Invalid username in order: {0}", username);
                }
                logger.TraceEvent(TraceEventType.Information, 0, "Order validated successfully");

                try {
                    // connect with the storehouse system and reserve one item
                    var storehouseUrl = "http://storehouse.example.com/ReserveItem?product=" + product;
                    logger.TraceInformation("Connecting with the ordering system: {0}", storehouseUrl);
                    // TODO: actucal connection with the url
                    
                    // send email to the delivery (or create a task or database record etc.)
                    var email = "chiefOfDelivery@example.com";
                    logger.TraceInformation("Informing a chief of delivery: {0}", email);
                    // TODO: send email
                    
                    order.Status = "OK";
                } catch (Exception ex) {
                    logger.TraceEvent(TraceEventType.Critical, 0, 
                            "Exception occured while trying to place the order: {0}", ex);
                    order.Status = "FAIL";
                    order.StatusMessage = ex.ToString();
                    if (order.StatusMessage.Length > MaxStatusMessageLength) {
                        order.StatusMessage = order.StatusMessage.Substring(0, MaxStatusMessageLength);
                    }
                }
                
                // save record to the database
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString)) {
                    conn.Open();
                    order.Id = (int)conn.Insert(order);
                }
                return order.Id;
            }
        }
    }
    
    public static class Program
    {
        public static void Main()
        {
            new OrderingSystem().PlaceOrder("test", "testprod", 12);
        }
    }
}