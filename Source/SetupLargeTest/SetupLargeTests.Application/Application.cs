using Accounting.Domain;

namespace SetupLargeTests.Application
{
    public class Application
    {
        private readonly AccountingService accountingService;

        public Application(AccountingService accountingService)
        {
            this.accountingService = accountingService;
        }

        public Money SumMoneys(Money left, Money right)
        {
            return accountingService.Sum(left, right);
        }
    }
}