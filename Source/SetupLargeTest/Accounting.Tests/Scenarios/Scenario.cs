using Accounting.Specs.Contexts;
using Accounting.Tests.Contexts;

namespace Accounting.Tests.Scenarios
{
    public partial class Scenario
    {
        private readonly TechnicalContext technicalContext;

        private Scenario()
        {
            moneyContext = new MoneyContext();
            changeRateContext = new ChangeRateContext();
            
            technicalContext = new TechnicalContext(changeRateContext);
        }

        public static Scenario Create()
        {
            return new Scenario();
        }
        
        public Scenario Given => this;
        public Scenario When => this;
        public Scenario Then => this;
        public Scenario And => this;
        public Scenario But => this;
    }
}