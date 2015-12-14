using System;

namespace OrderProcessing
{
    public class OrderProcessor
    {
        public void ShipOrder(Order order)
        {
             ValidateOrder(order);
             InitiateShipping(order);
             SaveOrder(order);
             LogOrder(order);
        }

        private void LogOrder(Order order)
        {
            var logger = new Logger();
            logger.Log("Order processed: " + order.ToString());
        }

        private void SaveOrder(Order order)
        {
            var dal = new OrderDataAccess();
            dal.SaveOrder(order);
        }

        private void InitiateShipping(Order order)
        {
            order.ShipDate = DateTime.Now;
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