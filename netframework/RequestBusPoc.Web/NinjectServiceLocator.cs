using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace RequestBusPoc.Web
{
    public class NinjectServiceLocator : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            this.kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}