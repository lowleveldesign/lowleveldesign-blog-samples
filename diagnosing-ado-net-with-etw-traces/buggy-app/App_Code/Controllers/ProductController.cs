using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Dapper;

namespace LowLevelDesign.DiagnosingAdoNet
{
    public class ProductController : Controller
    {
        public ActionResult Edit(String productKey) {
            Product prod = null;
            if (!String.IsNullOrEmpty(productKey)) {
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
                conn.Open();

                prod = conn.Query<Product>("select * from Products where ProductKey = @productKey", new { productKey }).SingleOrDefault();
            }
            return View(prod ?? new Product());
        }

        [HttpPost]
        public ActionResult Edit(Product product) {
            if (!ModelState.IsValid) {
                return View(product);
            }
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString)) {
              conn.Open();
              var t = conn.BeginTransaction();
              if (conn.Execute("update Products set Price = @Price where ProductKey = @ProductKey", product, t) == 0) {
                  conn.Execute("insert into Products values (@ProductKey, @Price)", product, t);
              }
              //t.Commit();
            }
            // save or update product
            return RedirectToAction("Index", "Home");
        }
    }
}