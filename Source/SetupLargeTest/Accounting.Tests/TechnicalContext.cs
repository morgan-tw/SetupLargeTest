using Accounting.Domain;
using Moq;

namespace Accounting.Tests
{
    public class TechnicalContext
    {
        private readonly Mock<ICurrencyConverter> currencyConverterMock;

        public TechnicalContext()
        {
            currencyConverterMock = new Mock<ICurrencyConverter>();
        }

        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;
        
        public void TheChangeRateFromToIs(string currencyFrom, string currencyTo, decimal changeRate)
        {
            currencyConverterMock.Setup(x => x.GetChangeRate(currencyFrom, currencyTo)).Returns(changeRate);
        }
    }
}