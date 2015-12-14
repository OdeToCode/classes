using System;

namespace OrderProcessing
{
    public interface IOrderDataAccess
    {
        void SaveOrder(Order order);
    }


    public class LoggingOrderDataAccess : OrderDataAccess
    {
        private readonly ILogger _logger;

        public LoggingOrderDataAccess(ILogger logger)
        {
            _logger = logger;
        }

        public override void SaveOrder(Order order)
        {
            //_logger.Log("About to save Order (ID)");
            base.SaveOrder(order);
            //_logger.Log("Saved Order (ID)");
        } 
    }

    public class OrderDataAccess : IOrderDataAccess
    {        
     
        public virtual void SaveOrder(Order order)
         {            
             Console.WriteLine("Order saved: " + order);
         }
    }
}