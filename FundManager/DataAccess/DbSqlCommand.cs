using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.DataAccess
{
    public class DbSqlCommand
    {
        public static SqlCommand GetSqlCommand ()
        {
            SqlConnection conn = DbConnection.GetConnection();

            return new SqlCommand("", conn);
        }
    }
}
