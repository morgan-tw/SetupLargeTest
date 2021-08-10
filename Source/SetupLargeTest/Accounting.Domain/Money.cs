namespace Accounting.Domain
{
    public class Money
    {        
        public Money(decimal amount, string currency = "BTH")
        {
            Amount = amount;
            Currency = currency;
        }
        
        public decimal Amount { get; }
        public string Currency { get; }

        public Money AddUsing(Money other, ICurrencyConverter currencyConverter)
        {
            var changeRate = currencyConverter.GetChangeRate(other.Currency, Currency);

            var money = new Money(Amount + other.Amount * changeRate, Currency);
            return money;
        }
    }
}