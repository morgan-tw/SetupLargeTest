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
            
            SetUpCurrencyConverter();
        }

        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;

        private void SetUpCurrencyConverter()
        {
            currencyConverterMock.Setup(x => x.GetChangeRate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string currencyFrom, string currencyTo) => changeRateContext.Get(currencyFrom, currencyTo));
        }
    }
}