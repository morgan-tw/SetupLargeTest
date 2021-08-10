namespace Accounting.Domain
{
    public class Money
    {
        public Money(int amount, string currency = "USD")
        {
            Amount = amount;
            Currency = currency;
        }
        
        public int Amount { get; }
        public string Currency { get; }

        public Money Add(Money other)
        {
            return new Money(Amount + other.Amount);
        }
        
        public static Money operator +(Money left, Money right)
            => left.Add(right);
    }
}