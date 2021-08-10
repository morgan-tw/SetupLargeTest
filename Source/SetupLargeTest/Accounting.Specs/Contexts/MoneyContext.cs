using System.Collections.Generic;
using System.Linq;
using Accounting.Domain;

namespace Accounting.Specs.Contexts
{
    public class MoneyContext
    {
        private readonly List<Money> items;
        private readonly Dictionary<string, Money> itemsPerKey;

        public MoneyContext()
        {
            items = new List<Money>();
            itemsPerKey = new Dictionary<string, Money>();
        }

        public Money EnsureAMoneyExist()
        {
            if (items.Count == 0)
            {
                Add(MoneyFactory.CreateDefaultMoney());
            }

            return items.First();
        }

        public Money EnsureTheMoneyExist(string key)
        {
            if (!itemsPerKey.ContainsKey(key))
            {
                Add(key, MoneyFactory.CreateDefaultMoney());
            }

            return itemsPerKey[key];
        }

        private void Add(Money item)
        {
           items.Add(item);
        }

        private void Add(string key, Money item)
        {
            Add(item);
            itemsPerKey.Add(key, item);
        }

        private class MoneyFactory
        {
            public static Money CreateDefaultMoney()
            {
                return new Money(0, "BTH");
            }
        }
    }
}