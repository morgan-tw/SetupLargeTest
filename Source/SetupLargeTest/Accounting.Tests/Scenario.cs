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
        public Scenario AMoneyWithAmount(string humanReadableKey, int amount)
        {
            items.Add(humanReadableKey, new Money(amount));
            return this;
        }
        #endregion

        #region When
        public Scenario WeAddTheMoneys(string leftKey, string rightKey)
        {
            result = items[leftKey] + items[rightKey];
            return this;
        }
        #endregion

        #region Then
        public Scenario ItsAmountShouldBe(string key,int expectedAmount)
        {
            Assert.That(items[key].Amount, Is.EqualTo(expectedAmount));
            return this;
        }

        public Scenario TheResultShouldBe(int expectedAmount)
        {
            Assert.That(result.Amount, Is.EqualTo(expectedAmount));
            return this;
        }
        #endregion
    }
}