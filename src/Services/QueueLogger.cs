using System;

namespace Services
{
    public class QueueLogger : IMessageLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Message '{message}' successfully queued");
        }
    }
}
