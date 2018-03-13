using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Tests.CommonHelpers
{

    public class Try
    {
        /// <summary>
        /// Assign an function you want to perform until a predication condition is met
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ITryRunnableAsync<TResult> ToExecute<TResult>(Func<Task<TResult>> action) where TResult : class
        {
            return new Tryable<TResult>(action);
        }

        /// <summary>
        /// Assign an function you want to perform until a predication condition is met
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ITryRunnable<TResult> ToExecute<TResult>(Func<TResult> action) where TResult : class
        {
            if (action.IsAwaitable())
            {
                throw new ArgumentException("Action cannot be a Func<Task<T>> use 'Try.GetResultAsync()' Method.");
            }

            return new Tryable<TResult>(action);
        }
    }

    internal static class FuncExtensions
    {
        public static bool IsAwaitable<TResult>(this Func<TResult> action) where TResult : class
        {
            var resultType = action
                .GetType()
                .GetGenericArguments()
                .First();

            return resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Task<>);
        }
    }
}
