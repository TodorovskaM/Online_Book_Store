using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.DBAccess
{
    public class DBAccess
    {
        public static SqlConnection GetOpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            return conn;
        }
    }
}
