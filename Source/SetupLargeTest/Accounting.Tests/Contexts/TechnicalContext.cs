using Accounting.Domain;
using Accounting.Tests.Fakes;
using Moq;

namespace Accounting.Tests.Contexts
{
    public class TechnicalContext
    {
        private ModuleAccountingFake moduleMoney;
        private Mock<ICurrencyConverter> currencyConverterMock;

        public TechnicalContext(ChangeRateContext changeRateContext)
        {
            moduleMoney = new ModuleAccountingFake();
            SetUpCurrencyConverter(changeRateContext);
        }

        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;

        private void SetUpCurrencyConverter(ChangeRateContext changeRateContext)
        {            
            currencyConverterMock = new Mock<ICurrencyConverter>();
            currencyConverterMock.Setup(x => x.GetChangeRate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string currencyFrom, string currencyTo) => changeRateContext.Get(currencyFrom, currencyTo));
        }
    }
}