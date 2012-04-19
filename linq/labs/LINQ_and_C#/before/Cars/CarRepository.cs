using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cars
{
    class CarRepository
    {
        public CarRepository(string fileName)
        {
            IEnumerable<Car> cars =
                from lines in File.ReadAllLines(fileName)
                let columns = lines.Split(',')
                where columns[0] != "Manufacturer"
                select new Car
                           {
                               Manufacturer = columns[0],
                               Name         = columns[1],
                               Displacement = Convert.ToDouble(columns[2]),
                               Cylinders    = Convert.ToInt32(columns[3]),
                               Transmission = columns[4],
                               CityMPG      = Convert.ToDouble(columns[6]),
                               HighwayMPG   = Convert.ToDouble(columns[7])
                           };
            _cars = cars.ToList();                                    
        }

        public IEnumerable<Car> FindAll()
        {
            return from c in _cars
                   orderby c.Manufacturer ascending
                   select c;
        }

        public IEnumerable<Car> FindBestMpg()
        {
            return from c in _cars
                   orderby (c.CityMPG + c.HighwayMPG) descending,
                           c.Manufacturer ascending
                   select c;            
        }

        public IEnumerable<Car> FindWorstMpg()
        {
            return from c in _cars
                   orderby (c.CityMPG + c.HighwayMPG) ascending, 
                           c.Manufacturer ascending
                   select c;
        }

        public void Export(string fileName)
        {
            XDocument document =
                new XDocument(
                    new XElement("cars",
                         from c in _cars
                         select new XElement("car",
                            new XAttribute("Manufacturer", c.Manufacturer),
                            new XAttribute("Name", c.Name),
                            // ... additional properties to save
                            new XAttribute("CityMPG", c.CityMPG),
                            new XAttribute("HighwayMPG", c.HighwayMPG)
                        )
                    )
                );
            document.Save(fileName);
        }

        public void Add(Car newCar)
        {
            _cars.Add(newCar);
        }

        private List<Car> _cars;
    }
}
