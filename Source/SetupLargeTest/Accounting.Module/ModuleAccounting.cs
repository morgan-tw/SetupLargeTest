using Accounting.Domain;
using Ninject.Modules;

namespace Accounting
{
    public class ModuleAccounting: NinjectModule
    {
        public override void Load()
        {
            Bind<ICurrencyConverter>().To<HardCodedCurrencyConverter>().InSingletonScope();
            Bind<AccountingService>().ToSelf().InSingletonScope();

            LoadExtensions();
        }

        protected virtual void LoadExtensions()
        {
        }
    }
}