using Accounting.Domain;
using NUnit.Framework;

namespace Accounting.Tests
{
    public class Scenario
    {
        private Money testable;

        private Scenario() {}

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
            testable = new Money(amount);
            return this;
        }

        public Scenario ItsAmountShouldBe(int expectedAmount)
        {
            Assert.That(testable.Amount, Is.EqualTo(expectedAmount));
            return this;
        }
    }
}