using System.Collections.Generic;
using Accounting.Domain;

namespace Accounting.Tests
{
    public class MoneyContext
    {
        public readonly Dictionary<string, Money> items;

        public MoneyContext()
        {
            items = new Dictionary<string, Money>();
        }
    }
}