﻿namespace RequestBusPoc.Domain.RequestBusModel
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest request);
    }
}