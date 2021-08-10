using System.Collections.Generic;
using System.Linq;
using Accounting.Domain;
using NUnit.Framework;

namespace Accounting.Tests
{
    public class Scenario
    {
        public Dictionary<string, Money> items;
        public Money result;

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

        public Scenario AMoneyWithAmount(string humanReadableKey, int amount)
        {
            items.Add(humanReadableKey, new Money(amount));
            return this;
        }

        public Scenario ItsAmountShouldBe(string key,int expectedAmount)
        {
            Assert.That(items[key].Amount, Is.EqualTo(expectedAmount));
            return this;
        }

        public Scenario WeAddTheMoneys(string leftKey, string rightKey)
        {
            result = items[leftKey] + items[rightKey];
            return this;
        }

        public Scenario TheResultShouldBe(int expectedAmount)
        {
            Assert.That(result.Amount, Is.EqualTo(expectedAmount));
            return this;
        }
    }
}