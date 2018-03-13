using System;
using System.Threading.Tasks;

namespace Library.Tests.CommonHelpers
{
    public class Tryable<TResult> : ITryRunnable<TResult>, ITryRunnableAsync<TResult>
    {
        public Tryable(Func<TResult> action)
        {
            this.Action = action;
        }

        public Tryable(Func<Task<TResult>> action)
        {
            this.AsyncAction = action;
        }

        private Func<Task<TResult>> AsyncAction { get; }

        private Func<TResult> Action { get; }

        private Func<TResult, bool> SuccessPredicate { get; set; } = r => r != null;

        private int Interval { get; set; } = 500;

        private int Retries { get; set; } = 20;

        ITryRunnable<TResult> ITryRunnable<TResult>.Until(Func<TResult, bool> until)
        {
            this.SuccessPredicate = until;
            return this;
        }

        ITryRunnableAsync<TResult> ITryRunnableAsync<TResult>.Until(Func<TResult, bool> until)
        {
            this.SuccessPredicate = until;
            return this;
        }

        ITryRunnable<TResult> ITryRunnable<TResult>.WithInterval(int interval)
        {
            this.Interval = interval;
            return this;
        }

        ITryRunnableAsync<TResult> ITryRunnableAsync<TResult>.WithInterval(int interval)
        {
            this.Interval = interval;
            return this;
        }

        ITryRunnable<TResult> ITryRunnable<TResult>.WithRetries(int retries)
        {
            this.Retries = retries;
            return this;
        }

        ITryRunnableAsync<TResult> ITryRunnableAsync<TResult>.WithRetries(int retries)
        {
            this.Retries = retries;
            return this;
        }

        public async Task<TResult> GetResultAsync()
        {
            var attempts = 0;
            var result = await this.AsyncAction.Invoke();

            while (!this.SuccessPredicate(result) && attempts < this.Retries)
            {
                attempts++;
                result = await this.AsyncAction.Invoke();
                await Task.Delay(this.Interval);
            }

            return result;
        }

        public TResult GetResult()
        {
            var attempts = 0;
            var result = this.Action.Invoke();

            while (!this.SuccessPredicate(result) && attempts < this.Retries)
            {
                attempts++;
                result = this.Action.Invoke();
                Task.Delay(this.Interval).Wait();
            }

            return result;
        }
    }

    public interface ITryRunnableAsync<TResult>
    {
        /// <summary>
        /// Execute the function set with <see cref="Try.ToExecute{TResult}(Func{Task{TResult}})"/>.
        /// </summary>
        /// <returns></returns>
        Task<TResult> GetResultAsync();

        /// <summary>
        /// Set the predicate to check for success which will stop further attempts.
        /// </summary>
        /// <param name="until"></param>
        /// <returns></returns>
        ITryRunnableAsync<TResult> Until(Func<TResult, bool> until);

        /// <summary>
        /// Set the interval between retries.
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        ITryRunnableAsync<TResult> WithInterval(int interval);

        /// <summary>
        /// Set the number of retry attempts to get the desired result.
        /// </summary>
        /// <param name="retries"></param>
        /// <returns></returns>
        ITryRunnableAsync<TResult> WithRetries(int retries);
    }

    public interface ITryRunnable<out TResult>
    {
        /// <summary>
        /// Execute the query set with <see cref="Try.ToExecute{TResult}(Func{TResult})"/>.
        /// </summary>
        /// <returns></returns>
        TResult GetResult();

        /// <summary>
        /// Set the predicate to check for success which will stop further attempts.
        /// </summary>
        /// <param name="until"></param>
        /// <returns></returns>
        ITryRunnable<TResult> Until(Func<TResult, bool> until);

        /// <summary>
        /// Set the interval between retries.
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        ITryRunnable<TResult> WithInterval(int interval);

        /// <summary>
        /// Set the number of retry attempts to get the desired result.
        /// </summary>
        /// <param name="retries"></param>
        /// <returns></returns>
        ITryRunnable<TResult> WithRetries(int retries);
    }
}