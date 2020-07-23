namespace Library.Equality
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A generic equality comparer.
    /// </summary>
    /// <typeparam name="T">The type to compare.</typeparam>
    public class GenericComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericComparer{T}"/> class.
        /// </summary>
        /// <param name="comparers">The list of comparer predicates.</param>
        public GenericComparer(params Func<T, T, bool>[] comparers)
            : this(null, comparers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericComparer{T}"/> class.
        /// </summary>
        /// <param name="getHashCode">The hash code function to use.</param>
        /// <param name="comparers">The list of comparer predicates.</param>
        public GenericComparer(Func<T, int> getHashCode, params Func<T, T, bool>[] comparers)
        {
            this.HashCodeAction = getHashCode;
            this.Actions = comparers;
        }

        private Func<T, T, bool>[] Actions { get; }

        private Func<T, int> HashCodeAction { get; }

        /// <inheritdoc />
        public bool Equals(T x, T y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            return this.Actions.All(action => action(x, y));
        }

        /// <inheritdoc />
        public int GetHashCode(T obj)
        {
            if (this.HashCodeAction == null)
            {
                throw new NotImplementedException();
            }

            return this.HashCodeAction(obj);
        }
    }
}
