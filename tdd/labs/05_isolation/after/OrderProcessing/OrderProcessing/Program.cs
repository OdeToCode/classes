using StructureMap;

namespace OrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ConfigureContainer();
            var order = new Order()
                            {
                                Origin = "MD",
                                Destination = "WA"
                            };            
            var processor = container.GetInstance<OrderProcessor>();
            processor.ShipOrder(order);
        }

        private static IContainer ConfigureContainer()
        {
            var container = new Container(c =>
            {
                c.For<ILogger>().Use<Logger>();
                c.For<IOrderDataAccess>().Use<OrderDataAccess>();
            });
            return container;
        }
    }
}
