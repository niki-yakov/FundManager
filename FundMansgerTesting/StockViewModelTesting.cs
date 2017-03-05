using FundManager.Interface;
using FundManager.Model;
using FundManager.ViewModel;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FundMansgerTesting
{
    public class StockViewModelTesting
    {
        Mock<IStockRepository> stockRepository = new Mock<IStockRepository>();
        Mock<IStockRepository> stockNotInToleranceRepository = new Mock<IStockRepository>();
        Mock<IStockTypeRepository> stockTypeRepository = new Mock<IStockTypeRepository>();

        public StockViewModelTesting()
        {
            List<StockTypeModel> stockTypes = new List<StockTypeModel>
            {
                new StockTypeModel{ Name = "Bond", Occurence = 1, Type = 1 },
                new StockTypeModel{ Name = "Equity", Occurence = 1, Type = 2 }
            };

            List<StockPropertyModel> stockProperty = new List<StockPropertyModel>()
            {
                new StockPropertyModel{ Id = 1, Cost = 0.05M, StockType = stockTypes[0], Tolerance = 100000 },
                new StockPropertyModel{ Id = 1, Cost = 0.002M, StockType = stockTypes[1], Tolerance = 200000 },
            };

            List<StockModel> stocks = new List<StockModel>
            {
                new StockModel
                {
                    ID = 1,
                    Name ="Stock1",
                    Price = 2,
                    Quantity = 3,
                    StockProperties = stockProperty[0]
                },
                new StockModel
                {
                    ID = 1,
                    Name ="Stock2",
                    Price = 2,
                    Quantity = 3,
                    StockProperties = stockProperty[1]
                }
            };

            List<StockModel> stocksNotInTolerance = new List<StockModel>
            {
                new StockModel
                {
                    ID = 1,
                    Name ="Stock3",
                    Price = 20000,
                    Quantity = 380000,
                    StockProperties = stockProperty[0]
                },
                new StockModel
                {
                    ID = 1,
                    Name ="Stock4",
                    Price = 20000,
                    Quantity = 380000,
                    StockProperties = stockProperty[1]
                }
            };

            stockRepository.Setup(c => c.GetAllStocks()).Returns(Task.FromResult(stocks));
            stockTypeRepository.Setup(c => c.GetAllStockTypes()).Returns(Task.FromResult(stockTypes));
            stockNotInToleranceRepository.Setup(c => c.GetAllStocks()).Returns(Task.FromResult(stocksNotInTolerance));
            
        }

        [Fact]
        public void GivenStockViewModelCreateAndInToleranceViewModel()
        {
            var stockViewModel = new StockViewModel(stockRepository.Object, stockTypeRepository.Object);

            //Bond
            Assert.Equal(2.00M, stockViewModel.Items[0].Price);
            Assert.Equal(3, stockViewModel.Items[0].Quantity);
            Assert.Equal(0.3M, stockViewModel.Items[0].TransactionCost);
            Assert.True(stockViewModel.Items[0].IsInTolerance);
            Assert.Equal(6.0M, stockViewModel.Items[0].MarketValue);
            Assert.Equal(50.0M, stockViewModel.Items[0].StockWeight);

            //Equity
            Assert.Equal(2.00M, stockViewModel.Items[1].Price);
            Assert.Equal(3, stockViewModel.Items[1].Quantity);
            Assert.Equal(0.012M, stockViewModel.Items[1].TransactionCost);
            Assert.True(stockViewModel.Items[1].IsInTolerance);
            Assert.Equal(6.0M, stockViewModel.Items[1].MarketValue);
            Assert.Equal(50.0M, stockViewModel.Items[1].StockWeight);
        }

        [Fact]
        public void GivenStockViewModelCreateNotInToleranceViewModel()
        {
            var stockViewModel = new StockViewModel(stockNotInToleranceRepository.Object, stockTypeRepository.Object);

            //Bond
            Assert.False(stockViewModel.Items[0].IsInTolerance);

            //Equity
            Assert.False(stockViewModel.Items[1].IsInTolerance);
        }
    }
}
