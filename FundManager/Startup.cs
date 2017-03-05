using Autofac;
using FundManager.Interface;
using FundManager.Repository;
using FundManager.ViewModel;
using log4net;

namespace FundManager
{
    public class Startup
    {
        public static IContainer Container = null;

        static Startup()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void ContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();

            builder.RegisterType<StockRepository>().As<IStockRepository>();
            builder.RegisterType<StockPropertyRepository>().As<IStockPropertyRepository>();
            builder.RegisterType<StockTypeRepository>().As<IStockTypeRepository>();

            builder.Register<StockViewModel>(
                c => new StockViewModel(
                    c.Resolve<IStockRepository>(), 
                    c.Resolve<IStockTypeRepository>())).As<IStockViewModel>();

            Container = builder.Build();
        }
    }
}
