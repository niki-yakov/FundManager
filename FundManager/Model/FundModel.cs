using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Model
{
    public class FundModel
    {
        
        public FundModel(List<StockModel> stocks)
        {
            Stocks = stocks;
            if (stocks.Count > 0)
            {
                this.TotalStock = stocks.Sum(c => c.Quantity);
                this.TotalMarketValue = stocks.Sum(c => c.MarketValue);
                this.TotalStockWeight = stocks.Sum(c => c.MarketValue) * 100 / TotalMarketValue;
                this.BondTotalNumber = stocks.Where(x => x.StockProperties.StockType.Type == (int)Stock.Bond).Sum(c => c.Quantity);
                this.BondTotalMarketValue = stocks.Where(x => x.StockProperties.StockType.Type == (int)Stock.Bond).Sum(c => c.MarketValue);
                this.BondTotalStockWeight = stocks.Where(x => x.StockProperties.StockType.Type == (int)Stock.Bond).Sum(c => c.MarketValue) * 100 / TotalMarketValue;
                this.EquityTotalNumber = stocks.Where(x => x.StockProperties.StockType.Type == (int)Stock.Equity).Sum(c => c.Quantity);
                this.EquityTotalMarketValue = stocks.Where(x => x.StockProperties.StockType.Type == (int)Stock.Equity).Sum(c => c.MarketValue);
                this.EquityTotalStockWeight = stocks.Where(x => x.StockProperties.StockType.Type == (int)Stock.Equity).Sum(c => c.MarketValue) * 100 / TotalMarketValue;

                stocks.ForEach((item) =>
                {
                    item.StockWeight = item.MarketValue * 100 / TotalMarketValue;
                });
            }
        }

        public int EquityTotalNumber { get; set; }
        public decimal EquityTotalStockWeight { get; set; }
        public decimal EquityTotalMarketValue { get; set; }

        public int BondTotalNumber { get; set; }
        public decimal BondTotalStockWeight { get; set; }
        public decimal BondTotalMarketValue { get; set; }

        public decimal TotalMarketValue { get; set; }
        public decimal TotalStockWeight { get; set; }
        public int TotalStock { get; set; }
        public List<StockModel> Stocks { get; private set; }
    }
}
