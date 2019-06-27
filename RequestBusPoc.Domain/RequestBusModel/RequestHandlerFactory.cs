using System;

namespace RequestBusPoc.Domain.RequestBusModel
{
    public class RequestHandlerFactory : IRequestHandlerFactory
    {
        public T Create<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}