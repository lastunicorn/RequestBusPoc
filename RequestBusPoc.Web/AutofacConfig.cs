using System.Web.Mvc;
using RequestBusPoc.Data.InMemory;
using RequestBusPoc.Domain;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Web
{
    internal class AutofacConfig
    {
        public static void SetupDependencyResolver()
        {
            ContainerBuilder builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());
            //builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            //builder.RegisterType<RequestBus>();
            builder.RegisterType<BookmarkRepository>().As<IBookmarkRepository>();
            builder.RegisterType<AutofacRequestHandlerFactory>().As<IRequestHandlerFactory>();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}