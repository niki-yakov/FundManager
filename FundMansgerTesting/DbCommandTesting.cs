using FundManager;
using FundManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FundMansgerTesting
{
    public class DbCommandTesting
    {
        public DbCommandTesting()
        {
            Startup.ContainerBuilder();
        }

        [Fact]
        public void DatabaseCommandCresteCommandTesting()
        {
            var dbConnection = DbSqlCommand.GetSqlCommand();
            Xunit.Assert.NotNull(dbConnection);
        }
    }
}
