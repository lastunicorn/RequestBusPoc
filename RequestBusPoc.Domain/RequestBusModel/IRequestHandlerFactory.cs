using System;

namespace RequestBusPoc.Domain.RequestBusModel
{
    public interface IRequestHandlerFactory
    {
        T Create<T>();
        object Create(Type type);
    }
}