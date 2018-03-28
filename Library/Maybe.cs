using System;

namespace Library
{
    public sealed class Maybe<T>
    {
        public Maybe()
        {
            this.HasItem = false;
        }

        public Maybe(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.HasItem = true;
            this.Item = item;
        }

        internal bool HasItem { get; }

        internal T Item { get; }

        public Maybe<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return this.HasItem 
                ? new Maybe<TResult>(selector(this.Item)) 
                : new Maybe<TResult>();
        }

        public T GetValueOrFallback(T fallbackValue)
        {
            if (fallbackValue == null)
            {
                throw new ArgumentNullException(nameof(fallbackValue));
            }

            return this.HasItem ? this.Item : fallbackValue;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<T> other))
            {
                return false;
            }

            return Equals(this.Item, other.Item);
        }

        public override int GetHashCode()
        {
            return this.HasItem ? this.Item.GetHashCode() : 0;
        }
    }
}
