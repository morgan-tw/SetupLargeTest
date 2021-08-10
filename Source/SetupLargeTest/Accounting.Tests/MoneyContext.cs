using System.Collections.Generic;
using System.Linq;
using Accounting.Domain;

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