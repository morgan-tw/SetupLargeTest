using System.Collections.Generic;
using Accounting.Domain;
using Moq;
using NUnit.Framework;

namespace Accounting.Tests
{
    public class Scenario
    {
        private readonly Mock<ICurrencyConverter> currencyConverterMock;
        
        private readonly Dictionary<string, Money> items;
        private Money result;

        private Scenario()
        {
            items = new Dictionary<string, Money>();
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
        public Scenario AMoneyWithAmount(string humanReadableKey, decimal amount, string currency = "BTH")
        {
            items.Add(humanReadableKey, new Money(amount, currency));
            return this;
        }
        #endregion

        #region When
        public Scenario WeAddTheMoneys(string leftKey, string rightKey)
        {
            result = items[leftKey].AddUsing(items[rightKey], currencyConverterMock.Object);
            return this;
        }
        #endregion

        #region Then
        public Scenario ItsAmountShouldBe(string key,decimal expectedAmount)
        {
            Assert.That(items[key].Amount, Is.EqualTo(expectedAmount));
            return this;
        }

        public Scenario TheResultShouldBe(decimal expectedAmount, string expectedCurrency)
        {
            Assert.That(result.Amount, Is.EqualTo(expectedAmount));
            Assert.That(result.Currency, Is.EqualTo(expectedCurrency));
            return this;
        }

        public Scenario TheChangeRateFromToIs(string currencyFrom, string currencyTo, decimal changeRate)
        {
            currencyConverterMock.Setup(x => x.GetChangeRate(currencyFrom, currencyTo)).Returns(changeRate);
            return this;
        }
        #endregion
    }
}