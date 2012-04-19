using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public string Transmission { get; set; }
        public int Cylinders { get; set; }
        public double CityMPG { get; set; }
        public double HighwayMPG { get; set; }
    }
}
