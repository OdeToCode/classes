using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Pluralsight.Linq
{
    public class PopulationStatistics
    {
        public PopulationStatistics()
        {
            Males = LoadFromXml("males.xml");
            Females = LoadFromXml("females.xml");
        }
        
        public IEnumerable<PopulationEntry> Males { get; set; }
        public IEnumerable<PopulationEntry> Females { get; set; }

        private IEnumerable<PopulationEntry> LoadFromXml(string fileName)
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
                    Population = double.Parse(e.Attribute("Population").Value)
                };
        }
    }
}