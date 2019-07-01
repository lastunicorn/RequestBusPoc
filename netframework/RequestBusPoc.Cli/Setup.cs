using Ninject;
using RequestBusPoc.Data.InMemory;
using RequestBusPoc.Domain;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Presentation
{
    internal class Setup
    {
        public static IKernel SetupDependencyResolver()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IBookmarkRepository>().To<BookmarkRepository>();
            kernel.Bind<IRequestHandlerFactory>().To<NinjectRequestHandlerFactory>();

            return kernel;
        }
    }
}