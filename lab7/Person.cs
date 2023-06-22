using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Person
    {
        static SqlConnection connection; 
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sun { get; set; }
        static Person()
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(strcon);
        }
    }
}
