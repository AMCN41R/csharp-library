using System;

namespace Library.DI
{
    public interface IServiceLocator
    {
        T Resolve<T>();

        object Resolve(Type type);
    }
}
