namespace FundManager.Model
{
    public class StockModel
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Type { get { return StockProperties?.StockType?.Name; } }
        public StockPropertyModel StockProperties { get; set; }
        public decimal MarketValue { get { return Price * Quantity; } }
        public decimal TransactionCost { get { return MarketValue * (this.StockProperties?.Cost ?? -1); } }
        public bool IsInTolerance { get { return !(MarketValue < 0 || TransactionCost > (this.StockProperties?.Tolerance ?? 0)); } }
        public decimal StockWeight { get; set; }

    }
}