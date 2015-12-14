using System.Collections.Generic;

namespace OrderProcessing.Tests
{
    public class FakeOrderDataAccess : IOrderDataAccess
    {
        public void SaveOrder(Order order)
        {
            SavedOrders.Add(order);
        }

        public List<Order> SavedOrders = new List<Order>();
    }
}