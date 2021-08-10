using Accounting.Tests.Contexts;

namespace Accounting.Tests.Scenarios
{
    public partial class Scenario
    {
        private readonly TechnicalContext technicalContext;

        private readonly ChangeRateContext changeRateContext;

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

        #region Given
        public Scenario TheChangeRateFromToIs(string currencyFrom, string currencyTo, decimal changeRate)
        {
            changeRateContext.Add(currencyFrom, currencyTo, changeRate);
            return this;
        }
        #endregion
    }
}