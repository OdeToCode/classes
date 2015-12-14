using System;

namespace OrderProcessing
{
    public class OrderProcessor
    {
        private IOrderDataAccess _orderDataAccess;
        private ILogger _logger;

        public OrderProcessor()
        {
            _orderDataAccess = new OrderDataAccess();
            _logger = new Logger();
        }

        public OrderProcessor(IOrderDataAccess orderDataAccess, ILogger logger)
        {
            _orderDataAccess = orderDataAccess;
            _logger = logger;
        }

         public void ShipOrder(Order order)
         {
             ValidateOrder(order);
             InitiateShipping(order);
             SaveOrder(order);
             LogOrder(order);
         }

        private void LogOrder(Order order)
        {
            _logger.Log("Order processed: " + order.ToString());
        }

        private void SaveOrder(Order order)
        {
            _orderDataAccess.SaveOrder(order);
        }

        private void InitiateShipping(Order order)
        {
            order.ShipDate = SystemTime.Now();
        }

        private static void ValidateOrder(Order order)
        {
            if (String.IsNullOrEmpty(order.Origin))
            {
                throw new ArgumentException("Order must have an origin", "order");
            }
            if (String.IsNullOrEmpty(order.Destination))
            {
                throw new ArgumentException("Order musy have a destination", "order");
            }
        }
    }
}