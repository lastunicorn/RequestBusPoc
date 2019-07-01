using System;

namespace RequestBusPoc.Domain.RequestBusModel
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}