using System;
using RequestBusPoc.Domain.RequestBusModel;
using Unity;

namespace RequestBusPoc.Web
{
    internal class UnityRequestHandlerFactory : IRequestHandlerFactory
    {
        private readonly IUnityContainer container;

        public UnityRequestHandlerFactory(IUnityContainer container)
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