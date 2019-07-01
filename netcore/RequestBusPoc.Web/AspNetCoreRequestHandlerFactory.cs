using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RequestBusPoc.Domain.RequestBusModel;

namespace RequestBusPoc.Web
{
    public class AspNetCoreRequestHandlerFactory : IRequestHandlerFactory
    {
        private readonly IServiceProvider serviceProvider;

        public AspNetCoreRequestHandlerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        public T Create<T>()
        {
            return (T)ResolveType(typeof(T));
        }

        public object Create(Type type)
        {
            return ResolveType(type);
        }

        private object ResolveType(Type serviceType)
        {
            ParameterInfo[][] constructors = serviceType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.GetParameters())
                .ToArray()
                .OrderByDescending(o => o.Length)
                .ToArray();

            if (!constructors.Any())
                return null;

            object[] arguments = ResolveParameters(serviceProvider, constructors);

            return arguments == null
                ? null
                : Activator.CreateInstance(serviceType, arguments);
        }

        private static object[] ResolveParameters(IServiceProvider resolver, IEnumerable<ParameterInfo[]> constructors)
        {
            foreach (ParameterInfo[] constructor in constructors)
            {
                bool hasNull = false;
                object[] values = new object[constructor.Length];

                for (int i = 0; i < constructor.Length; i++)
                {
                    object value = resolver.GetService(constructor[i].ParameterType);
                    values[i] = value;

                    if (value == null)
                    {
                        hasNull = true;
                        break;
                    }
                }

                if (!hasNull)
                {
                    // found a constructor we can create.
                    return values;
                }
            }

            return null;
        }
    }
}