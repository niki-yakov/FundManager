using FundManager.DataAccess;
using FundManager.Interface;
using FundManager.Model;
using log4net;
using System;
using System.Collections.Generic;

namespace FundManager.Repository
{
    public class StockPropertyRepository : IStockPropertyRepository
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(StockPropertyRepository));
        private static readonly bool isDebugEnabled = _logger.IsDebugEnabled;

        public IList<StockPropertyModel> GetAllStockProperties()
        {
            using (var command = DbSqlCommand.GetSqlCommand())
            {
                try
                {
                    command.CommandText = SqlConstants.StockProperty.spGetAllProperties;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    var stockProperties = new List<StockPropertyModel>();

                    while (reader.Read())
                    {
                        stockProperties.Add(new StockPropertyModel
                        {
                                Id = reader.GetInt32(3),
                                Cost = reader.GetDecimal(4),
                                Tolerance = reader.GetDecimal(5),
                                StockType = new StockTypeModel
                                {
                                    Type = reader.GetInt32(7),
                                    Name = reader.GetString(8),
                                    Occurence = reader.GetInt32(7),
                                }
                        });
                    }

                    return stockProperties;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
                finally
                {
                    command.Connection.Close();
                    _logger.Debug("DbConnection");
                }

                return null;
            }
        }
    }
}
