using System.Collections.Generic;
using FundManager.Model;
using System.Threading.Tasks;

namespace FundManager.Interface
{
    public interface IStockRepository
    {
        Task<List<StockModel>> GetAllStocks();
        Task<List<StockModel>> AddStock(int type, decimal price, int quantity, int occurence);
    }
}