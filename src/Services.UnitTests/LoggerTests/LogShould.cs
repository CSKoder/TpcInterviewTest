using System;
using Xunit;

namespace Services.UnitTests.LoggerTests
{
    public class LogShould
    {
        // Using fake message logger
        class TestLogger : IMessageLogger
        {
            public void Log(string message)
            {
                return;
            }
        }

        [Fact]
        public void Call_Log_with_message()
        {
            var logger = new Logger(LogType.Queue);
            logger.Log("test");
        }

        [Fact]
        public void Throw_argument_exception()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Logger((LogType)3));
            Assert.Equal("Unknown log type\r\nParameter name: logType", ex.Message);
        }

        [Fact]
        public void Call_Log_with_message_alt_ctor()
        {
            var logger = new Logger(new TestLogger());
            logger.Log("test");
        }

        [Fact]
        public void Throw_argument_null_exception()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Logger(null));
            Assert.Equal("Message logger cannot be passed null\r\nParameter name: logger", ex.Message);
        }
    }
}
