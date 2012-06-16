<%@ Page Language="C#" Debug="true" AutoEventWireup="true" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Dapper.Contrib.Extensions" %>

<script runat="server">
   
   sealed class Order 
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


    public int PlaceOrder(String username, String product, decimal cash) 
    {
          // create an order record
          var order = new Order {
                          Username = username,
                          Product = product,
                          Cash = cash,
                          // we comment the below on purpose to force the SqlTypeException
                          // CreatedOn = DateTime.UtcNow,
                      };
        
          // save record to the database
          using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString)) {
              conn.Open();
              order.Id = (int)conn.Insert(order);
          }
          return order.Id;
    }
    
    protected void Page_Load(object sender, EventArgs args) {
        PlaceOrder("test", "testprod", 12);
    }
</script>

<!DOCTYPE html>
<html>
<head>
</head>
<body>
  Should never get here.
</body>
</html>
