using System.Collections.Generic;
using Accounting.Domain;
using NUnit.Framework;

namespace Accounting.Tests
{
    public class Scenario
    {
        private readonly Dictionary<string, Money> items;
        private Money result;

        private Scenario()
        {
            items = new Dictionary<string, Money>();
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
        public Scenario AMoneyWithAmount(string humanReadableKey, decimal amount)
        {
            items.Add(humanReadableKey, new Money(amount));
            return this;
        }
        #endregion

        #region When
        public Scenario WeAddTheMoneysUsing(string leftKey, string rightKey, ICurrencyConverter currencyConverter)
        {
            result = items[leftKey].AddUsing(items[rightKey], currencyConverter);
            return this;
        }
        #endregion

        #region Then
        public Scenario ItsAmountShouldBe(string key,decimal expectedAmount)
        {
            Assert.That(items[key].Amount, Is.EqualTo(expectedAmount));
            return this;
        }

        public Scenario TheResultShouldBe(decimal expectedAmount)
        {
            Assert.That(result.Amount, Is.EqualTo(expectedAmount));
            return this;
        }
        #endregion
    }
}