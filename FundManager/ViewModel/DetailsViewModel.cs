using FundManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.ViewModel
{
    public class DetailsViewModel
    {
        FundModel fund = null;
        public DetailsViewModel(FundModel fund)
        {
            this.fund = fund;
        }
        public int EquityTotalNumber { get { return fund.EquityTotalNumber; } }
        public decimal EquityTotalStockWeight { get { return fund.EquityTotalStockWeight; } }
        public decimal EquityTotalMarketValue { get { return fund.EquityTotalMarketValue; } }

        public int BondTotalNumber { get { return fund.BondTotalNumber; } }
        public decimal BondTotalStockWeight { get { return fund.BondTotalStockWeight; } }
        public decimal BondTotalMarketValue { get { return fund.BondTotalMarketValue; } }

        public decimal TotalMarketValue { get { return fund.TotalMarketValue; } }
        public decimal TotalStockWeight { get { return fund.TotalStockWeight; } }
        public int TotalStock { get { return fund.TotalStock; } }

    }
}
