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
    public class StockRepository : IStockRepository
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(StockRepository));
        private static readonly bool isDebugEnabled = _logger.IsDebugEnabled;

        public Task<List<StockModel>> GetAllStocks()
        {
            using (var command = DbSqlCommand.GetSqlCommand())
            {
                try
                {
                    command.CommandText = SqlConstants.Stock.spGetAllStocks;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    var stocks = new List<StockModel>();

                    while (reader.Read())
                    {
                        stocks.Add(new StockModel
                        {
                            ID = reader.GetInt32(0),
                            Quantity = reader.GetInt32(1),
                            Price = reader.GetDecimal(2),
                            Name = reader.GetString(3),
                            StockProperties = new StockPropertyModel
                            {
                                Id = reader.GetInt32(4),
                                Cost = reader.GetDecimal(5),
                                Tolerance = reader.GetDecimal(6),
                                StockType = new StockTypeModel
                                {
                                    Type = reader.GetInt32(7),
                                    Name = reader.GetString(8),
                                    Occurence = reader.GetInt32(9),
                                }
                            }
                        });
                    }

                    return Task.FromResult<List<StockModel>>(stocks);
                }
                catch(Exception ex)
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

        public Task<List<StockModel>> AddStock(int type, decimal price, int quantity, int occurence)
        {
            using (var command = DbSqlCommand.GetSqlCommand())
            {
                try
                {
                    command.CommandText = SqlConstants.Stock.spAddStock;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@occurence", occurence);

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    var stocks = new List<StockModel>();

                    while (reader.Read())
                    {
                        stocks.Add(new StockModel
                        {
                            ID = reader.GetInt32(0),
                            Quantity = reader.GetInt32(1),
                            Price = reader.GetDecimal(2),
                            Name = reader.GetString(3),
                            StockProperties = new StockPropertyModel
                            {
                                Id = reader.GetInt32(4),
                                Cost = reader.GetDecimal(5),
                                Tolerance = reader.GetDecimal(6),
                                StockType = new StockTypeModel
                                {
                                    Type = reader.GetInt32(7),
                                    Name = reader.GetString(8),
                                    Occurence = reader.GetInt32(9),
                                }
                            }
                        });
                    }

                    return Task.FromResult<List<StockModel>>(stocks);
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
