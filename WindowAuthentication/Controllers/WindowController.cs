using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WindowAuthentication.Models;

namespace WindowAuthentication.Controllers
{
    public class WindowController : Controller
    {

        string str = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;


        // GET: Window
        [Authorize]
        public ActionResult Index()
        {
            List<Employee> emplist = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(str))
            {
                string qry = "select * from Employees";
                SqlCommand cmd = new SqlCommand(qry, conn);
                conn.Open();    
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emplist.Add(new Employee
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Age = Convert.ToInt32(reader["age"]),
                        DOB = Convert.ToDateTime(reader["DOB"])
                    });
                }
            }
                return View(emplist);
        }
    }
}