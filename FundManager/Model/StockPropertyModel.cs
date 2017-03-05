using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Model
{
    public class StockPropertyModel
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public decimal Tolerance { get; set; }
        public StockTypeModel StockType { get; set; }
    }
}


