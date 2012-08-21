using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Population.Models
{
    public class PopulationStatistics
    {
        public PopulationStatistics()
        {
            _males = LoadFromXml("males.xml");
            _females = LoadFromXml("females.xml");
        }

        public double GetMalePopulation(string country, int year)
        {
            return
                _males.Where(pe => pe.Country.ToLower() == country.ToLower() &&
                                   pe.Year == year)
                      .First()
                      .Population;
        }

        public double GetFemalePopulation(string country, int year)
        {
            return _females.Where(pe => pe.Country.ToLower() == country.ToLower() &&
                                   pe.Year == year)
                           .First()
                           .Population;
        }

        public IEnumerable<string> GetCountries()
        {
            var countries =
                    _males.Concat(_females)
                         .Select(p => p.Country)
                         .Distinct()
                         .OrderBy(name => name)
                         .ToList();
            return countries;
        }

        public IEnumerable<int> GetAvailableYearsForCountry(string country)
        {
            var years =
                _males.Concat(_females)
                     .Where(c => c.Country.ToLower() == country.ToLower())
                     .Select(c => c.Year)
                     .Distinct()
                     .OrderByDescending(year => year)
                     .ToList();
            return years;
        }

        IEnumerable<PopulationEntry> LoadFromXml(string fileName)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"),
                                       fileName);
            
            XDocument doc = XDocument.Load(path);
            return 
                from e in doc.Elements("Populations").Elements("Country")
                select new PopulationEntry 
                {
                    Country = e.Attribute("Name").Value,
                    Year = int.Parse(e.Attribute("Year").Value),
                    Population = double.Parse(e.Attribute("Population").Value,
				CultureInfo.GetCultureInfo("en-us").NumberFormat)
                };
        }

        IEnumerable<PopulationEntry> _males { get; set; }
        IEnumerable<PopulationEntry> _females { get; set; }

    }
}