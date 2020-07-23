namespace Library.DI
{
    using System;

    using Autofac;

    /// <summary>
    /// Autofac implementation of the <see cref="IServiceLocator"/>.
    /// </summary>
    public class AutofacServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceLocator"/> class.
        /// </summary>
        /// <param name="componentContext">The Autofac component context.</param>
        public AutofacServiceLocator(IComponentContext componentContext)
        {
            this.Context = componentContext;
        }

        private IComponentContext Context { get; }

        /// <inheritdoc />
        public object Resolve(Type type)
        {
            return this.Context.Resolve(type);
        }

        /// <inheritdoc />
        public T Resolve<T>()
        {
            return this.Context.Resolve<T>();
        }
    }
}