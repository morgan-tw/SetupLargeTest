using System.Linq;
using Accounting.Domain;
using NUnit.Framework;

namespace Accounting.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class MoneyTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        public void Should_set_amount(int amount)
        {
            Scenario.Create().
                Given.AMoneyWithAmount(amount).
                Then.ItsAmountShouldBe(amount);
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Sum_with_zero_should_not_change_amount(int amount)
        {
            var scenario = Scenario.Create().
                Given.AMoneyWithAmount(0).
                And.AMoneyWithAmount(amount).
                When.WeAddTheMoneys(0, 1);
            
            Assert.That(scenario.result.Amount, Is.EqualTo(amount));
        }
    }
}
