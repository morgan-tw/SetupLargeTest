using Accounting.Domain;
using Moq;

namespace Accounting.Tests
{
    public class TechnicalContext
    {
        private readonly ChangeRateContext changeRateContext;
        
        private readonly Mock<ICurrencyConverter> currencyConverterMock;

        public TechnicalContext(ChangeRateContext changeRateContext)
        {
            this.changeRateContext = changeRateContext;
            currencyConverterMock = new Mock<ICurrencyConverter>();
        }

        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;
        
        public void TheChangeRateFromToIs(string currencyFrom, string currencyTo)
        {
            currencyConverterMock.Setup(x => x.GetChangeRate(currencyFrom, currencyTo))
                .Returns((string from, string to) => changeRateContext.Get(from, to));
        }
    }
}