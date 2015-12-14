using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Utility;
using System.Linq.Expressions;

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
                               Manufacturer = columns[0].PrettyCase(),
                               Name         = columns[1].PrettyCase(),
                               Displacement = Convert.ToDouble(columns[2]),
                               Cylinders    = Convert.ToInt32(columns[3]),
                               Transmission = columns[4],
                               CityMPG      = Convert.ToDouble(columns[6]),
                               HighwayMPG   = Convert.ToDouble(columns[7])
                           };
            _cars = cars.ToList();                                    
        }

        public IEnumerable<Car> 
                 Find(Expression<Func<Car, bool>> specification)
        {
            //BinaryExpression binary = specification.Body as BinaryExpression;

            //BinaryExpression newBinary = 
            //    Expression.LessThan(binary.Left, binary.Right)            

            //Expression<Func<Car,bool>> newExpression = 
            //    Expression.Lambda<Func<Car,bool>>(newBinary,
            //                      specification.Parameters.ToArray());
                            
            return _cars.Where(specification.Compile())
                        .Select(c => c);
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
