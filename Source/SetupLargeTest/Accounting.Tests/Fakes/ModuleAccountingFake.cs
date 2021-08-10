using Accounting.Domain;
using Accounting.Tests.Contexts;
using Moq;

namespace Accounting.Tests.Fakes
{
    public class ModuleAccountingFake: ModuleAccounting
    {
        private Mock<ICurrencyConverter> currencyConverterMock;

        public ModuleAccountingFake(ChangeRateContext changeRateContext)
        {
            SetUpCurrencyConverter(changeRateContext);
        }
        
        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;
        
        private void SetUpCurrencyConverter(ChangeRateContext changeRateContext)
        {            
            currencyConverterMock = new Mock<ICurrencyConverter>();
            currencyConverter = currencyConverterMock.Object;
            currencyConverterMock.Setup(x => x.GetChangeRate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string currencyFrom, string currencyTo) => changeRateContext.Get(currencyFrom, currencyTo));
        }
    }
}