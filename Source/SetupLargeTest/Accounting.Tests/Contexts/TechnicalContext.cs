using Accounting.Tests.Fakes;

namespace Accounting.Tests.Contexts
{
    public class TechnicalContext
    {
        public TechnicalContext(ChangeRateContext changeRateContext)
        {
            ModuleAccounting = new ModuleAccountingFake(changeRateContext);
        }

        public ModuleAccountingFake ModuleAccounting { get; }
    }
}