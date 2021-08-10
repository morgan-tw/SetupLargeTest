namespace Accounting.Domain
{
    public class AccountingService
    {
        private readonly ICurrencyConverter currencyConverter;

        public AccountingService(ICurrencyConverter currencyConverter)
        {
            this.currencyConverter = currencyConverter;
        }

        public Money Sum(Money left, Money right)
        {
            return left.AddUsing(right, currencyConverter);
        }
    }
}