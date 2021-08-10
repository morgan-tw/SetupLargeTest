using Accounting.Domain;
using Accounting.Specs.Contexts;
using Moq;

namespace Accounting.Specs
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
            currencyConverterMock.Setup(x => x.GetChangeRate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string currencyFrom, string currencyTo) => changeRateContext.Get(currencyFrom, currencyTo));
        }

        public override void Load()
        {
            Rebind<ICurrencyConverter>().ToConstant(currencyConverterMock.Object).InSingletonScope();
        }
    }
}