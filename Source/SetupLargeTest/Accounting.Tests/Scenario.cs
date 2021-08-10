namespace Accounting.Tests
{
    public partial class Scenario
    {
        private readonly TechnicalContext technicalContext;

        private Scenario()
        {
            moneyContext = new MoneyContext();
            technicalContext = new TechnicalContext();
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
            technicalContext.TheChangeRateFromToIs(currencyFrom, currencyTo, changeRate);
            return this;
        }
        #endregion
    }
}