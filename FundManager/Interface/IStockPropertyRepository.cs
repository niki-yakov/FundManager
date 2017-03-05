using System.Collections.Generic;
using FundManager.Model;

namespace FundManager.Interface
{
    public interface IStockPropertyRepository
    {
        IList<StockPropertyModel> GetAllStockProperties();
    }
}