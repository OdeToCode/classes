using System;

namespace OrderProcessing
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("{0}: {1}", DateTime.UtcNow, message);
        }
    }
}