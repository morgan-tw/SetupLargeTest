using System.Collections.Generic;
using Accounting.Domain;
using NUnit.Framework;

namespace Accounting.Tests
{
    public class Scenario
    {
        public List<Money> items;

        private Scenario()
        {
            items = new List<Money>();
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

        public Scenario AMoneyWithAmount(int amount)
        {
            items.Add(new Money(amount));
            return this;
        }

        public Scenario ItsAmountShouldBe(int expectedAmount)
        {
            Assert.That(items[0].Amount, Is.EqualTo(expectedAmount));
            return this;
        }
    }
}