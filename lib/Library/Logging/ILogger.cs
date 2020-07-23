namespace Library.Logging
{
    using System;

    /// <summary>
    /// A simple logging interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="ex">The exception.</param>
        void LogError(string message, Exception ex);

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="message">The error message.</param>
        void LogError(string message);

        /// <summary>
        /// Logs a warning.
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <param name="ex">The exception.</param>
        void LogWarning(string message, Exception ex);

        /// <summary>
        /// Logs a warning.
        /// </summary>
        /// <param name="message">The warning message.</param>
        void LogWarning(string message);

        /// <summary>
        /// Logs information.
        /// </summary>
        /// <param name="message">The information message.</param>
        /// <param name="ex">The exception.</param>
        void LogInfo(string message, Exception ex);

        /// <summary>
        /// Logs information.
        /// </summary>
        /// <param name="message">The information message.</param>
        void LogInfo(string message);

        /// <summary>
        /// Logs a trace message.
        /// </summary>
        /// <param name="message">The trace message.</param>
        /// <param name="ex">The exception.</param>
        void LogTrace(string message, Exception ex);

        /// <summary>
        /// Logs a trace message.
        /// </summary>
        /// <param name="message">The trace message.</param>
        void LogTrace(string message);
    }
}
