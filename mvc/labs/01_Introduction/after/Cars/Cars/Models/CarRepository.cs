using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class CarRepository
    {
        public CarRepository(string path)
        {
            _cars = File.ReadAllLines(path)
                        .Skip(1) // skip the header record
                        .Select(line => line.Split(','))
                        .Select(fields =>
                            new Car
                            {
                                Manufacturer = fields[0],
                                ModelName = fields[1],
                                AverageMPG =
                                    (double.Parse(fields[6]) +
                                     double.Parse(fields[7])) / 2
                            }).ToList();
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars;
        }


        public IEnumerable<string> GetManufacturers()
        {
            var result = _cars.Select(c => c.Manufacturer)
                              .Distinct()
                              .OrderBy(s => s);
            return result;
        }

        List<Car> _cars;
    }

}