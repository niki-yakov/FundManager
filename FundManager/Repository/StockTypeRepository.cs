using FundManager.DataAccess;
using FundManager.Interface;
using FundManager.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Repository
{
    public class StockTypeRepository : IStockTypeRepository
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(StockTypeRepository));
        private static readonly bool isDebugEnabled = _logger.IsDebugEnabled;
        public Task<List<StockTypeModel>> GetAllStockTypes()
        {
            string spGetAllStocks = SqlConstants.Stock.spGetAllStocks;

            using (var command = DbSqlCommand.GetSqlCommand())
            {
                try
                {
                    command.CommandText = SqlConstants.StockType.spGetAllStockTypes;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    var stockType = new List<StockTypeModel>();

                    while (reader.Read())
                    {
                        stockType.Add(new StockTypeModel
                        {
                            Type = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Occurence = reader.GetInt32(2),
                        });
                    }

                    return Task.FromResult<List<StockTypeModel>>(stockType);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
                finally
                {
                    command.Connection.Close();
                }

                return null;
            }
        }
    }
}
