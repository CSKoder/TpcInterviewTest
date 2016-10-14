using System;

namespace Services
{
    /// <summary>
    /// This class is designed to perform a basic logging function.
    /// In the future, we might want to expand our logging capabilities. 
    /// 
    /// Currently, this class doesn't follow SOLID and would require too much modification to extext. 
    /// It violates the Open Close Principle. 
    /// 
    /// Please refactor this method and provide tests in Services.UnitTests.LoggerTests.LogShould.
    /// 
    /// 
    /// Hint:
    /// 
    /// public class ConsoleLogger : IMessageLogger {}
    /// public class QueueLogger : IMessageLogger {}
    /// </summary>
    public class Logger
    {
        private IMessageLogger _logger;

        /// <summary>
        /// Suggested constructor
        /// </summary>
        /// <param name="logType"></param>
        public Logger(LogType logType)
        {
            switch (logType)
            {
                case LogType.Console:
                    _logger = new ConsoleLogger();
                    break;

                case LogType.Queue:
                    _logger = new QueueLogger();
                    break;

                default:
                    throw new ArgumentException("Unknown log type", nameof(logType));
            }
        }

        /// <summary>
        /// Alternative constructor
        /// Does not require Enums
        /// Injectable service
        /// </summary>
        /// <param name="logger"></param>
        public Logger(IMessageLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "Message logger cannot be passed null");
            }
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }

        [Obsolete("Please use Log method overload with the single parameter", true)]
        public void Log(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Console:
                    Console.WriteLine(message);
                    break;

                case LogType.Queue:
                    // Code to send message to printer
                    break;
            }
        }
    }
    
    public enum LogType
    {
        Console,
        Queue
    }
}
