using FundManager.Command;
using FundManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FundManager.ViewModel
{
    public class AddStockViewModel : ViewModelBase
    {
        private List<StockTypeModel> stockType = null;
        public List<StockTypeModel> StockType
        {
            get
            {
                return stockType;
            }
            set
            {
                if (value != null)
                {
                    stockType = value;
                    NotifyPropertyChanged("StockType");
                }
            }
        }

        private StockTypeModel currentSelection = null;
        public StockTypeModel Selected
        {
            get { return currentSelection; }
            set
            {
                currentSelection = value;
                Name = string.Format("{0}{1}", value.Name, (value.Occurence + 1).ToString());
                NextOccurence = (value.Occurence + 1);
                NotifyPropertyChanged("Selected");
            }
        }

        private decimal price = 0;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }

        private int quantity = 0;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private string name = null;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public int NextOccurence { get; set; }

        public RelayCommand AddStockCommand { get; set; }

        public AddStockViewModel(RelayCommand addStockCommand)
        {
            AddStockCommand = addStockCommand;
        }
    }
}
