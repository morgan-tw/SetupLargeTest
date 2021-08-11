using Accounting.Specs.Contexts;

namespace SetupLargeTests.Specs.Scenarios
{
    public partial class Scenario
    {
        private readonly ChangeRateContext changeRateContext;
        
        #region Given
        public Scenario TheChangeRateFromToIs(string currencyFrom, string currencyTo, decimal changeRate)
        {
            changeRateContext.Add(currencyFrom, currencyTo, changeRate);
            return this;
        }
        #endregion
    }
}