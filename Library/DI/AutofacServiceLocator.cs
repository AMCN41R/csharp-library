using System;
using Autofac;

namespace Library.DI
{
    public class AutofacServiceLocator : IServiceLocator
    {
        public AutofacServiceLocator(IComponentContext componentContext)
        {
            this.Context = componentContext;
        }

        private IComponentContext Context { get; }

        public object Resolve(Type type)
        {
            return this.Context.Resolve(type);
        }

        public T Resolve<T>()
        {
            return this.Context.Resolve<T>();
        }
    }
}