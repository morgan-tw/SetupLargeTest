using System.Collections.Generic;

namespace Accounting.Tests.Contexts
{
    public class ChangeRateContext
    {
        private Dictionary<string, Dictionary<string, decimal>> changeRates;

        public ChangeRateContext()
        {
            changeRates = new Dictionary<string, Dictionary<string, decimal>>();
        }

        public void Add(string currencyFrom, string currencyTo, decimal changeRate)
        {
            EnsureChangeRateExistFrom(currencyFrom);

            if (changeRates[currencyFrom].ContainsKey(currencyTo))
            {
                changeRates[currencyFrom][currencyTo] = changeRate;
            }
            else
            {
                changeRates[currencyFrom].Add(currencyTo, changeRate);
            }
        }

        private void EnsureChangeRateExistFrom(string currencyFrom)
        {
            if (!changeRates.ContainsKey(currencyFrom))
            {
                changeRates.Add(currencyFrom, new Dictionary<string, decimal>());
            }
        }

        public decimal Get(string currencyFrom, string currencyTo)
        {
            return changeRates[currencyFrom][currencyTo];
        }
    }
}