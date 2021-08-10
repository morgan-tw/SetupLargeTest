using Accounting.Domain;
using Accounting.Tests.Contexts;
using NUnit.Framework;

namespace Accounting.Tests.Scenarios
{
    public partial class Scenario
    {
        private readonly MoneyContext moneyContext; 
        private Money result;
        
        #region Given
        public Scenario AMoney(decimal amount, string currency)
        {
            var money = moneyContext.EnsureAMoneyExist();
            money.Amount = amount;
            money.Currency = currency;
            return this;
        }

        public Scenario AMoneyHasForAmount(decimal amount)
        {
            moneyContext.EnsureAMoneyExist().Amount = amount;
            return this;
        }

        public Scenario AMoneyHasForCurrency(string currency)
        {
            moneyContext.EnsureAMoneyExist().Currency = currency;
            return this;
        }

        public Scenario ThisMoneyHasForCurrency(string currency)
        {
            return AMoneyHasForCurrency(currency);
        }
        
        public Scenario ThisMoneyHasForAmount(decimal amount)
        {
            return AMoneyHasForAmount(amount);
        }
        
        public Scenario TheMoney(string humanReadableKey, decimal amount, string currency)
        {
            var money = moneyContext.EnsureTheMoneyExist(humanReadableKey);
            money.Amount = amount;
            money.Currency = currency;
            return this;
        }
        
        public Scenario TheMoneyHasForAmount(string humanReadableKey, decimal amount)
        {
            var money = moneyContext.EnsureTheMoneyExist(humanReadableKey);
            money.Amount = amount;
            return this;
        }
        
        public Scenario TheMoneyHasForCurrency(string humanReadableKey, string currency)
        {
            var money = moneyContext.EnsureTheMoneyExist(humanReadableKey);
            money.Currency = currency;
            return this;
        }
        #endregion

        #region When
        public Scenario WeAddTheMoneys(string leftKey, string rightKey)
        {
            var leftMoney = moneyContext.EnsureTheMoneyExist(leftKey);
            var rightMoney = moneyContext.EnsureTheMoneyExist(rightKey);
            result = leftMoney.AddUsing(rightMoney, technicalContext.CurrencyConverter);
            return this;
        }
        #endregion

        #region Then
        public Scenario ItsAmountShouldBe(decimal expectedAmount)
        {
            Assert.That(moneyContext.EnsureAMoneyExist().Amount, Is.EqualTo(expectedAmount));
            return this;
        }
        
        public Scenario ItsCurrencyShouldBe(string expectedCurrency)
        {
            Assert.That(moneyContext.EnsureAMoneyExist().Currency, Is.EqualTo(expectedCurrency));
            return this;
        }

        public Scenario TheResultShouldBe(decimal expectedAmount, string expectedCurrency)
        {
            Assert.That(result.Amount, Is.EqualTo(expectedAmount));
            Assert.That(result.Currency, Is.EqualTo(expectedCurrency));
            return this;
        }

        
        #endregion
    }
}