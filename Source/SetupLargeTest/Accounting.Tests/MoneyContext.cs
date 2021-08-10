using System.Collections.Generic;
using System.Linq;
using Accounting.Domain;
using Castle.Core.Internal;

namespace Accounting.Tests
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
            if (items.IsNullOrEmpty())
            {
                Add(new Money(0, "BTH"));
            }

            return items.First();
        }

        public Money EnsureTheMoneyExist(string key)
        {
            if (!itemsPerKey.ContainsKey(key))
            {
                Add(key, new Money(0, "BTH"));
            }

            return itemsPerKey[key];
        }

        public void Add(Money item)
        {
           items.Add(item);
        }
        
        public void Add(string key, Money item)
        {
            items.Add(item);
            itemsPerKey.Add(key, item);
        }

        public Money Get()
        {
            return items.First();
        }

        public Money Get(string key)
        {
            return itemsPerKey[key];
        }
    }
}