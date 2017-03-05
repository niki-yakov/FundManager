using Autofac;
using FundManager.Command;
using FundManager.Interface;
using FundManager.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace FundManager.ViewModel
{
    public class StockViewModel : ViewModelBase, IStockViewModel
    {
        private ObservableCollection<StockModel> items = new ObservableCollection<StockModel>();
        public ObservableCollection<StockModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                if (value != null)
                {
                    items = value;
                    NotifyPropertyChanged("Items");
                }
            }
        }

        private FundModel fund = null;
        public FundModel Fund
        {
            get
            {
                return fund;
            }
            set
            {
                if (value != null)
                {
                    fund = value;
                }
            }
        }

        private DetailsViewModel details = null;
        public DetailsViewModel Details
        {
            get { return details; }
            set
            {
                if (value != null)
                {
                    details = value;
                    NotifyPropertyChanged("Details");
                }
            }
        }

        private AddStockViewModel addStock = null;
        public AddStockViewModel AddStock
        {
            get { return addStock; }
            set
            {
                if (value != null)
                {
                    addStock = value;
                    NotifyPropertyChanged("AddStock");
                }
            }
        }

        public RelayCommand GetAllStockCommand { get; private set; }
        public RelayCommand GetAllStockTypeCommand { get; private set; }
        public RelayCommand AddStockCommnad { get; set; }

        readonly public IStockTypeRepository _stockTypeRepository = null;

        readonly private IStockRepository _stockRepository = null;

        public StockViewModel(IStockRepository stockRepository, IStockTypeRepository stockTypeRepository)
        {
            _stockRepository = stockRepository;
            _stockTypeRepository = stockTypeRepository;

            GetAllStockCommand = new RelayCommand(o => GetAllStocksMethod(), o => true);
            GetAllStockCommand.Execute(null);

            GetAllStockTypeCommand = new RelayCommand(o => GetAllStockTypeMethod(), o => true);
            GetAllStockTypeCommand.Execute(null);

            AddStockCommnad = new RelayCommand(o => AddStockMethod(), o => true);
        }

        async private void GetAllStocksMethod()
        {
            FundModel fund = new FundModel(new List<StockModel>(await _stockRepository.GetAllStocks()));

            Items = new ObservableCollection<StockModel>(fund.Stocks);

            Fund = fund;

            Details = new DetailsViewModel(Fund);
        }

        async private void GetAllStockTypeMethod()
        {
            var stockType = new List<StockTypeModel>(await _stockTypeRepository.GetAllStockTypes());

            AddStockCommnad = new RelayCommand(o => AddStockMethod(), o => true);

            AddStock = new AddStockViewModel(AddStockCommnad) { StockType = stockType };
        }

        async private void AddStockMethod()
        {
            var stock = await _stockRepository.AddStock(AddStock.Selected.Type, AddStock.Price, AddStock.Quantity, AddStock.NextOccurence);

            GetAllStockCommand.Execute(null);

            GetAllStockTypeCommand.Execute(null);
        }
    }
}
