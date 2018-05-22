namespace Library.Logging
{
    using System;

    /// <summary>
    /// An NLog implementation of the <see cref="ILogger"/> interface.
    /// </summary>
    public class NLogLogger : ILogger
    {
        private static NLog.Logger Logger { get; } = NLog.LogManager.GetCurrentClassLogger();

        /// <inheritdoc />
        public void LogError(string message, Exception ex)
        {
            Logger.Error(ex, message);
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <inheritdoc />
        public void LogWarning(string message, Exception ex)
        {
            Logger.Warn(ex, message);
        }

        /// <inheritdoc />
        public void LogWarning(string message)
        {
            Logger.Warn(message);
        }

        /// <inheritdoc />
        public void LogInfo(string message, Exception ex)
        {
            Logger.Info(ex, message);
        }

        /// <inheritdoc />
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <inheritdoc />
        public void LogTrace(string message, Exception ex)
        {
            Logger.Trace(ex, message);
        }

        /// <inheritdoc />
        public void LogTrace(string message)
        {
            Logger.Trace(message);
        }
    }
}