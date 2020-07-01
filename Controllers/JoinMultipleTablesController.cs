using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Join_Tables_SP.Models;
using Microsoft.Extensions.Configuration;


namespace Join_Tables_SP.Controllers
{
    public class JoinMultipleTablesController : Controller
    {
        private IConfiguration Configuration;
        private static string connection;

        public JoinMultipleTablesController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            connection = this.Configuration.GetConnectionString("BookStoresDB");
            ViewData["Message"] = joinTables();
            return View();
        }

        public static List<JoinTablesClass> joinTables()
        {
            List<JoinTablesClass> jt = new List<JoinTablesClass>();
            //string connection =   "Data Source=DESKTOP-GORUVUT;Initial Catalog=BookStoresDB;Integrated Security=False;User Id=user;Password=user;MultipleActiveResultSets=True";
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                using(SqlCommand sqlcom = new SqlCommand("[dbo].[JoinTables]", sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr = sqlcom.ExecuteReader();
                    while(sdr.Read())
                    {
                        JoinTablesClass jtc = new JoinTablesClass();
                        jtc.author_name = sdr["author_name"].ToString();
                        jtc.book_title = sdr["book_title"].ToString();
                        jtc.publisher_name = sdr["publisher_name"].ToString();
                        jt.Add(jtc);
                    }
                }
            }
            return jt;
            }

    }
}
