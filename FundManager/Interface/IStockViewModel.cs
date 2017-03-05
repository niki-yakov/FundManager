using System.Collections.ObjectModel;
using FundManager.Command;
using FundManager.Model;
using FundManager.ViewModel;

namespace FundManager.Interface
{
    public interface IStockViewModel
    {
        AddStockViewModel AddStock { get; set; }
        RelayCommand AddStockCommnad { get; set; }
        DetailsViewModel Details { get; set; }
        FundModel Fund { get; set; }
        RelayCommand GetAllStockCommand { get; }
        RelayCommand GetAllStockTypeCommand { get; }
        ObservableCollection<StockModel> Items { get; set; }
    }
}