namespace Accounting.Domain
{
    public interface ICurrencyConverter
    {
        public decimal GetChangeRate(string currency, string otherCurrency);
    }
}