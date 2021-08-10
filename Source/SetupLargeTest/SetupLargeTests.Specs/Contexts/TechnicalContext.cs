using System.Collections.Generic;
using Accounting.Specs;
using Accounting.Specs.Contexts;
using Ninject.Modules;
using SetupLargeTests.Application;

namespace SetupLargeTests.Specs.Contexts
{
    public class TechnicalContext: Bootstrapper
    {
        private readonly List<INinjectModule> fakeModules;
        
        public TechnicalContext(ChangeRateContext changeRateContext)
        {
            fakeModules = new List<INinjectModule>
            {
                new ModuleAccountingFake(changeRateContext) 
            };
        }

        public Application.Application Application => StartApplication();

        protected override void ExtendModules(List<INinjectModule> modules)
        {
            modules.AddRange(fakeModules);
        }
    }
}