using Accounting.Tests.Scenarios;
using NUnit.Framework;

namespace Accounting.Tests.Features
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
        public void Should_set_amount(decimal amount)
        {
            Scenario.Create().
                Given.AMoneyHasForCurrency("BTH").
                And.ThisMoneyHasForAmount(amount).
                Then.ItsAmountShouldBe(amount).
                And.ItsCurrencyShouldBe("BTH");
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Sum_with_zero_should_not_change_amount(decimal amount)
        {
            Scenario.Create().
                Given.TheChangeRateFromToIs("BTH", "BTH", 1).
                And.TheMoneyHasForAmount("Zero", 0).
                And.TheMoney("Money", amount, "BTH").
                And.TheMoneyHasForCurrency("Zero", "BTH").
                When.WeAddTheMoneys("Zero", "Money").
                Then.TheResultShouldBe(amount, "BTH");
        }
        
        [Test]
        public void Sum_with_different_currencies_should_apply_the_change_rate()
        {
            Scenario.Create().
                Given.TheChangeRateFromToIs("AUD", "BTH", 2).
                And.TheMoney("tenBath", 10, "BTH").
                And.TheMoney("tenDollars", 10, "AUD").
                When.WeAddTheMoneys("tenBath", "tenDollars").
                Then.TheResultShouldBe(30, "BTH");
        }
    }
}
