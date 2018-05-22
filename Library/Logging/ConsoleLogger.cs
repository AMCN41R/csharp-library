namespace Library.Logging
{
    using System;

    /// <summary>
    /// An implementation of the <see cref="ILogger"/> interface that writes
    /// messages to the console.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <inheritdoc />
        public void LogError(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogWarning(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogWarning(string message)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogInfo(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogTrace(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public void LogTrace(string message)
        {
            Console.WriteLine(message);
        }
    }
}