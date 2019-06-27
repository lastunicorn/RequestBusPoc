using System;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Web
{
    internal class AutofacRequestHandlerFactory : IRequestHandlerFactory
    {
        private readonly ILifetimeScope container;

        public AutofacRequestHandlerFactory(ILifetimeScope container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public T Create<T>()
        {
            return container.Resolve<T>();
        }

        public object Create(Type type)
        {
            return container.Resolve(type);
        }
    }
}