using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using FundManager;
using FundManager.DataAccess;
using System.Data;

namespace FundMansgerTesting
{
    public class DbConnectionTesting
    {
        public DbConnectionTesting()
        {
            Startup.ContainerBuilder();
        }

        [Fact]
        public void GivenDatabaseConnectionTestCreateConnection()
        {
            var connection = DbConnection.GetConnection();
            Xunit.Assert.NotNull(connection);
        }

        [Fact]
        public void GivenDatabaseConnectionTestOpenConnection()
        {
            var connection = DbConnection.GetConnection();
            connection.Open();
            Xunit.Assert.Equal(ConnectionState.Open, connection.State);
        }

        [Fact]
        public void GivenDatabaseConnectionTestCloseConnection()
        {
            var connection = DbConnection.GetConnection();
            connection.Open();
            connection.Close();
            Xunit.Assert.Equal(ConnectionState.Closed, connection.State);
        }
    }
}
