using System;

namespace OrderProcessing
{
    public interface IOrderDataAccess
    {
        void SaveOrder(Order order);
    }

    public class OrderDataAccess : IOrderDataAccess
    {
         public void SaveOrder(Order order)
         {
             Console.WriteLine("Order saved: " + order);
         }
    }
}