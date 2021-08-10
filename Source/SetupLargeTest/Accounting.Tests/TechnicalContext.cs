using Accounting.Domain;
using Moq;

namespace Accounting.Tests
{
    public class TechnicalContext
    {
        private readonly ChangeRateContext changeRateContext;
        
        private readonly Mock<ICurrencyConverter> currencyConverterMock;

        public TechnicalContext()
        {
            changeRateContext = new ChangeRateContext();
            currencyConverterMock = new Mock<ICurrencyConverter>();
        }

        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;
        
        public void TheChangeRateFromToIs(string currencyFrom, string currencyTo, decimal changeRate)
        {
            changeRateContext.Add(currencyFrom, currencyTo, changeRate);
            currencyConverterMock.Setup(x => x.GetChangeRate(currencyFrom, currencyTo)).Returns(
                (string from, string to) => changeRateContext.Get(from, to));
        }
    }
}