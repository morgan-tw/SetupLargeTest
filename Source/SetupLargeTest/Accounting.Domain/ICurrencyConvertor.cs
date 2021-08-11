namespace Accounting.Domain
{
    public interface ICurrencyConverter
    {
        public decimal GetChangeRate(string currencyFrom, string currencyTo);
    }
}