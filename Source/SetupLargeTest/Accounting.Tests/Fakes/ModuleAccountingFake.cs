using Accounting.Domain;
using Accounting.Tests.Contexts;
using Moq;

namespace Accounting.Tests.Fakes
{
    public class ModuleAccountingFake
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

        public Money Add(Money leftMoney, Money rightMoney)
        {
            return leftMoney.AddUsing(rightMoney, currencyConverterMock.Object);
        }
    }

}