using System.Collections.Generic;
using System.Linq;
using Library.Guards;

namespace Library.CommonExtensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Determines whether a given <see cref="IEnumerable{T}"/> is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to check.</param>
        /// <returns>True if the list is either null or empty, else false.</returns>
        public static bool IsNullOrEmpty<T>([ValidatedNotNull] this IEnumerable<T> list) where T : class
        {
            return list == null || !list.Any();
        }

        /// <summary>Concatenates the members of a collection, using the specified separator between each member.</summary>
        /// <param name="list">A collection that contains the objects to concatenate.</param>
        /// <param name="separator">The string to use as a separator.<paramref name="separator" /> is included in the returned string only if <paramref name="list" /> has more than one element.</param>
        /// <typeparam name="T">The type of the members of <paramref name="list" />.</typeparam>
        /// <returns>A string that consists of the members of <paramref name="list" /> delimited by the <paramref name="separator" /> string. If <paramref name="list" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="list" /> is null. </exception>
        public static string Join<T>(this IEnumerable<T> list, string separator) where T : class
        {
            Guard.AgainstNullArgument(nameof(list), list);

            return string.Join(separator, list);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>If the key is found, the value associated with the specified key, otherwise, the default value for the type of value parameter.</returns>
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            Guard.AgainstNullArgument(nameof(dictionary), dictionary);

            dictionary.TryGetValue(key, out var value);
            return value;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultToKey">If true returns key as value when key not found.</param>
        /// <returns>If the key is found, the value associated with the specified key. If the key is not found, the key or the default value for the type of value parameter.</returns>
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, bool defaultToKey) where TKey : TValue
        {
            Guard.AgainstNullArgument(nameof(dictionary), dictionary);

            if (dictionary.TryGetValue(key, out TValue value))
            {
                return value;
            }

            return defaultToKey ? key : default(TValue);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">THe value t return if the key is not found in the dictionary.</param>
        /// <returns>If the key is found, the value associated with the specified key, otherwise, the specified default value.</returns>
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            Guard.AgainstNullArgument(nameof(dictionary), dictionary);

            if (dictionary.TryGetValue(key, out TValue value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
