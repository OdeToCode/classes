using StructureMap;

namespace OrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order()
                            {
                                Origin = "MD",
                                Destination = "WA"
                            };


            var processor = new OrderProcessor();
            processor.ShipOrder(order);
        }
    }
}
