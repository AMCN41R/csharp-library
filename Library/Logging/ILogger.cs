using System;

namespace Library.Logging
{
    public interface ILogger
    {
        void LogError(string message, Exception ex);

        void LogError(string message);

        void LogWarning(string message, Exception ex);

        void LogWarning(string message);

        void LogInfo(string message, Exception ex);

        void LogInfo(string message);

        void LogTrace(string message, Exception ex);

        void LogTrace(string message);
    }
}
