using System;

namespace Library.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        public void LogError(string message)
        {
            Console.WriteLine(message);
        }

        public void LogWarning(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        public void LogWarning(string message)
        {
            Console.WriteLine(message);
        }

        public void LogInfo(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void LogTrace(string message, Exception ex)
        {
            Console.WriteLine(message);
        }

        public void LogTrace(string message)
        {
            Console.WriteLine(message);
        }
    }
}