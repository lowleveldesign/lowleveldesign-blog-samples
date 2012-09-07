using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Dapper;

namespace LowLevelDesign.DiagnosingAdoNet 
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            using (var conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconn"].ConnectionString)) 
            {
                conn.Open();
                return View(conn.Query<Product>("select * from Products"));
            }
        }
    }
}