using Accounting.Domain;
using Moq;
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
        public void Should_set_amount(decimal amount)
        {
            Scenario.Create().
                Given.AMoneyWithAmount("My money", amount).
                Then.ItsAmountShouldBe("My money", amount);
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Sum_with_zero_should_not_change_amount(decimal amount)
        {
            var scenario = Scenario.Create();
            
            scenario.currencyConverterMock.Setup(x => x.GetChangeRate("BTH", "BTH")).Returns(1);
            
            scenario.
                Given.AMoneyWithAmount("Zero", 0).
                And.AMoneyWithAmount("Money", amount).
                When.WeAddTheMoneysUsing("Zero", "Money", scenario.currencyConverterMock.Object).
                Then.TheResultShouldBe(amount);
        }
        
        [Test]
        public void Sum_with_different_currency_should_apply_the_change_rate()
        {
            var currencyConverterMock = Scenario.Create().currencyConverterMock;
            currencyConverterMock.Setup(x => x.GetChangeRate("AUD", "BTH")).Returns(2);
            
            var tenBath = new Money(10, "BTH");
            var tenDollars = new Money(10, "AUD");

            var result = tenBath.AddUsing(tenDollars, currencyConverterMock.Object);
            
            Assert.That(result.Amount, Is.EqualTo(30));
            Assert.That(result.Currency, Is.EqualTo("BTH"));
        }
    }
}
