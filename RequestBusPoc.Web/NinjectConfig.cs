using System.Web;
using System.Web.Mvc;

namespace RequestBusPoc.Web
{
    internal class NinjectConfig
    {
        public static void SetupDependencyResolver()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            kernel.Bind<IBookmarkRepository>().To<BookmarkRepository>();
            kernel.Bind<IRequestHandlerFactory>().To<NinjectRequestHandlerFactory>();


            NinjectServiceLocator ninjectServiceLocator = new NinjectServiceLocator(kernel);
            DependencyResolver.SetResolver(ninjectServiceLocator);
        }
    }
}