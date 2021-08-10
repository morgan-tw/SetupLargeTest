using Accounting.Domain;

namespace Accounting.Tests
{
    public class Scenario
    {
        public Money testable;

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
    }
}