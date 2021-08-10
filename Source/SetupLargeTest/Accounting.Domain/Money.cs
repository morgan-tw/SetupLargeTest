namespace Accounting.Domain
{
    public class Money
    {
        public Money(int amount, string currency = "USD")
        {
            Amount = amount;
            Currency = currency;
        }
        
        public int Amount { get; set; }
        public string Currency { get; set; }
    }
}