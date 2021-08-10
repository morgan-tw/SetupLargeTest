using Accounting.Domain;
using Moq;

namespace Accounting.Tests
{
    public partial class Scenario
    {
        private readonly TechnicalContext technicalContext;
        private readonly Mock<ICurrencyConverter> currencyConverterMock;

        private Scenario()
        {
            moneyContext = new MoneyContext();
            technicalContext = new TechnicalContext();
            currencyConverterMock = new Mock<ICurrencyConverter>();
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
            currencyConverterMock.Setup(x => x.GetChangeRate(currencyFrom, currencyTo)).Returns(changeRate);
            return this;
        }
        #endregion
    }
}