using Accounting.Domain;
using Accounting.Tests.Fakes;

namespace Accounting.Tests.Contexts
{
    public class TechnicalContext
    {
        private readonly ModuleAccountingFake moduleMoney;

        public TechnicalContext(ChangeRateContext changeRateContext)
        {
            moduleMoney = new ModuleAccountingFake(changeRateContext);
        }

        public ICurrencyConverter CurrencyConverter => moduleMoney.CurrencyConverter;

        
    }
}