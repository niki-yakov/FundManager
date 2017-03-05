using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.DataAccess
{
    public class DbConnection
    {
        public static SqlConnection GetConnection()
        {
            string conn = ConfigurationManager.ConnectionStrings["dbConn"]?.ToString();

            return new SqlConnection(conn);
        }
    }
}
