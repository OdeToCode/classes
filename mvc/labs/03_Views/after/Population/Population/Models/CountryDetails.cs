using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Population.Models
{
    public class CountryDetails
    {
        public string Name { get; set; }
        public IEnumerable<SelectListItem>
                       AvailableYears { get; set; }
        public double MalePopulation { get; set; }
        public double FemalePopulation { get; set; }
        public double TotalPopulation { get; set; }


    }
}