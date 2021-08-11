namespace Accounting.Domain
{
    public class Money
    {        
        public Money(decimal amount, string currency = "BTH")
        {
            Amount = amount;
            Currency = currency;
        }
        
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Money AddUsing(Money other, ICurrencyConverter currencyConverter)
        {
            var changeRate = currencyConverter.GetChangeRate(other.Currency, Currency);

            var money = new Money(Amount + other.Amount * changeRate, Currency);
            return money;
        }

        public override string ToString()
        {
            return $"{Currency} {Amount}";
        }
    }
}