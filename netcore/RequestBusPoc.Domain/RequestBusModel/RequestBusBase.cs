using System;
using System.Collections.Generic;

namespace RequestBusPoc.Domain.RequestBusModel
{
    public class RequestBusBase : IRequestBus
    {
        private readonly IRequestHandlerFactory requestHandlerFactory;
        private readonly Dictionary<Type, Type> handlers = new Dictionary<Type, Type>();

        public RequestBusBase()
        {
            requestHandlerFactory = new RequestHandlerFactory();
        }

        public RequestBusBase(IRequestHandlerFactory requestHandlerFactory)
        {
            this.requestHandlerFactory = requestHandlerFactory ?? throw new ArgumentNullException(nameof(requestHandlerFactory));
        }

        public void Register<TRequest, THandler>()
        {
            Type requestType = typeof(TRequest);
            Type requestHandlerType = typeof(THandler);

            if (handlers.ContainsKey(requestType))
                throw new Exception("The type " + requestType.FullName + " is already registered.");

            handlers.Add(requestType, requestHandlerType);
        }

        public TResponse ProcessRequest<TRequest, TResponse>(TRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Type requestType = typeof(TRequest);

            if (!handlers.ContainsKey(requestType))
                throw new Exception("No handler is registered for the specified request.");

            if (request is IValidatableObject validatableRequest)
                validatableRequest.Validate();

            Type requestHandlerType = handlers[requestType];
            IRequestHandler<TRequest, TResponse> requestHandler = (IRequestHandler<TRequest, TResponse>)requestHandlerFactory.Create(requestHandlerType);

            return requestHandler.Handle(request);
        }
    }
}