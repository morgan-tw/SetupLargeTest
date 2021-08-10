using Accounting.Domain;
using Moq;

namespace Accounting.Tests
{
    public class TechnicalContext
    {
        public readonly Mock<ICurrencyConverter> currencyConverterMock;

        public TechnicalContext()
        {
            currencyConverterMock = new Mock<ICurrencyConverter>();
        }

        public ICurrencyConverter CurrencyConverter => currencyConverterMock.Object;
    }
}