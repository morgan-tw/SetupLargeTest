namespace Accounting.Domain
{
    public class ModuleAccounting
    {
        protected ICurrencyConverter currencyConverter;
        
        public Money Add(Money leftMoney, Money rightMoney)
        {
            return leftMoney.AddUsing(rightMoney, currencyConverter);
        }
    }
}