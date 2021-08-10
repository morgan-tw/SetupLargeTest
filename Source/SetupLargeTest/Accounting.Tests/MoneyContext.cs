using System.Collections.Generic;
using Accounting.Domain;

namespace Accounting.Tests
{
    public class MoneyContext
    {
        private readonly Dictionary<string, Money> items;

        public MoneyContext()
        {
            items = new Dictionary<string, Money>();
        }

        public void Add(string key, Money item)
        {
            items.Add(key, item);
        }

        public Money Get(string key)
        {
            return items[key];
        }
    }
}