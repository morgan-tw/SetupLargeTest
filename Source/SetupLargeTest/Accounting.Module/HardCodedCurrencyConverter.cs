using System.Collections.Generic;
using Accounting.Domain;

namespace Accounting
{
    public class HardCodedCurrencyConverter: ICurrencyConverter
    {
        private Dictionary<string, Dictionary<string, decimal>> changeRates;

        public HardCodedCurrencyConverter()
        {
            changeRates = new Dictionary<string, Dictionary<string, decimal>>
            {
                { "BTH", new Dictionary<string, decimal>{ {"AUD", 0.5M}, {"BTH", 1} } },
                { "AUD", new Dictionary<string, decimal>{ {"BTH", 2}, {"AUD", 1} } },
            };
        }
        
        public decimal GetChangeRate(string currencyFrom, string currencyTo)
        {
            return changeRates[currencyFrom][currencyTo];
        }
    }
}