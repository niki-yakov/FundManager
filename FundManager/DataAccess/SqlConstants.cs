using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.DataAccess
{
    public static class SqlConstants
    {
        public static class StockProperty
        {
            public const string spGetAllProperties = "sp_GetAllProperties";
        }

        public static class Stock
        {
            public const string spGetAllStocks = "sp_GetAllStocks";
            public const string spAddStock = "sp_AddStock";
        }

        public static class StockType
        {
            public const string spGetAllStockTypes = "sp_GetAllStockTypes";
        }
    }
}
