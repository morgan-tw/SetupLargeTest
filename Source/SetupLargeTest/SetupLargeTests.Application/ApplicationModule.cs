using Ninject.Modules;

namespace SetupLargeTests.Application
{
    public class ApplicationModule: NinjectModule
    {
        public override void Load()
        {
            Bind<Application>().ToSelf();
        }
    }
}