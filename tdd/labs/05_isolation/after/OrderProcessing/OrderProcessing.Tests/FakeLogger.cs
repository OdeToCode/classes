using System.Collections.Generic;

namespace OrderProcessing.Tests
{
    public class FakeLogger : ILogger
    {
        public void Log(string message)
        {
            LogMessages.Add(message);
        }

        public List<string> LogMessages = new List<string>();
    }
}