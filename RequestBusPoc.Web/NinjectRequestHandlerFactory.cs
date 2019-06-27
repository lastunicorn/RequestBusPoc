using System;
using Ninject;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Presentation
{
    internal class NinjectRequestHandlerFactory : IRequestHandlerFactory
    {
        private readonly IKernel kernel;

        public NinjectRequestHandlerFactory(IKernel kernel)
        {
            this.kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public T Create<T>()
        {
            return kernel.Get<T>();
        }

        public object Create(Type type)
        {
            return kernel.Get(type);
        }
    }
}