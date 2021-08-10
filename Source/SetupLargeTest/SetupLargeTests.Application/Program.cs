using System;
using Accounting.Domain;

namespace SetupLargeTests.Application
{
    public static class Program
    {
        private static readonly Application Application = new Bootstrapper().StartApplication();
        
        public static void Main(string[] args)
        {
            var left = new Money(Convert.ToDecimal(args[0]), args[1]);
            var right = new Money(Convert.ToDecimal(args[2]), args[3]);
            
            Console.WriteLine(Application.SumMoneys(left, right));
        }
    }
}