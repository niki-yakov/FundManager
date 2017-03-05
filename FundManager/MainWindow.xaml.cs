using Autofac;
using FundManager.Interface;
using System.Windows;

namespace FundManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = Startup.Container.Resolve<IStockViewModel>();
        }
    }
}
