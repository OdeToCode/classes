using System;

namespace OrderProcessing
{
    public class Order
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ShipDate { get; set; }

        public override string ToString()
        {
            return String.Format("Origin:{0} Destination:{1} ShipDate:{2}", Origin, Destination, ShipDate);
        }
    }
}