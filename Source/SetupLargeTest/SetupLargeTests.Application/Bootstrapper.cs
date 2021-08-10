using System.Collections.Generic;
using Accounting;
using Accounting.Domain;
using Ninject;
using Ninject.Modules;

namespace SetupLargeTests.Application
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            Container = new StandardKernel();
        }

        private StandardKernel Container { get; }

        public void Load()
        {
            var modules = new List<INinjectModule>
            {
                new ModuleAccounting(),
                new ApplicationModule()
            };

            ExtendModules(modules);

            Container.Load(modules);
        }

        protected virtual void ExtendModules(List<INinjectModule> modules)
        {
        }

        public Application StartApplication()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Load();
            return bootstrapper.Container.Get<Application>();
        }
    }
}