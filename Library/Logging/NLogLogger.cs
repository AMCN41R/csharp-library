using System;

namespace Library.Logging
{
    public class NLogLogger : ILogger
    {
        private static NLog.Logger Logger { get; } = NLog.LogManager.GetCurrentClassLogger();

        public void LogError(string message, Exception ex)
        {
            Logger.Error(ex, message);
        }

        public void LogError(string message)
        {
            Logger.Error(message);
        }

        public void LogWarning(string message, Exception ex)
        {
            Logger.Warn(ex, message);
        }

        public void LogWarning(string message)
        {
            Logger.Warn(message);
        }

        public void LogInfo(string message, Exception ex)
        {
            Logger.Info(ex, message);
        }

        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        public void LogTrace(string message, Exception ex)
        {
            Logger.Trace(ex, message);
        }

        public void LogTrace(string message)
        {
            Logger.Trace(message);
        }
    }
}