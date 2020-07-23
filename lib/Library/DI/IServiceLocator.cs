namespace Library.DI
{
    using System;

    /// <summary>
    /// The service locator interface.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Resolves <typeparamref name="T"/> from the container.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>An instance of <typeparamref name="T"/> from the container.</returns>
        T Resolve<T>();

        /// <summary>
        /// Resolves a type from the container.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>An instance of the type from the container.</returns>
        object Resolve(Type type);
    }
}
