namespace Library.Equality
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ComparerFactory
    {
        public static IEqualityComparer<T> GetComparer<T>()
            where T : class
        {
            return new ClassComparer<T>();
        }

        internal static bool JsonCompare<T>(T x, T y)
            where T : class
        {
            if ((x == null && y == null) || ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            var isVal = typeof(T).IsValueType;
            var isString = typeof(T) == typeof(string);
            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(typeof(T));

            if (!isEnumerable && (isVal || isString))
            {
                return x.Equals(y);
            }

            var xx = JsonConvert.SerializeObject(x);
            var yy = JsonConvert.SerializeObject(y);

            return xx == yy;
        }
    }

    public class ClassComparer<T> : IEqualityComparer<T>
        where T : class
    {
        public bool Equals(T x, T y)
        {
            return ComparerFactory.JsonCompare(x, y);
        }

        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
