using System.Collections.Generic;
using System.Threading.Tasks;
using FundManager.Model;

namespace FundManager.Interface
{
    public interface IStockTypeRepository
    {
        Task<List<StockTypeModel>> GetAllStockTypes();
    }
}