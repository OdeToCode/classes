using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Population.Models;

namespace Population.Controllers
{
    public class PopulationController : Controller
    {
        //
        // GET: /Population/

        public ActionResult Index()
        {
            var statistics = new PopulationStatistics();
            var countries = statistics.GetCountries();

            return View(countries);
        }


        public ActionResult Details(string id, int? year)
        {
            var statistics = new PopulationStatistics();
            var details = new CountryDetails();

            var availableYears =
                           statistics.GetAvailableYearsForCountry(id);

            details.Name = id;
            details.AvailableYears =
                      availableYears.Select(availableYear =>
                                            new SelectListItem
                                            {
                                                Text = availableYear.ToString(),
                                                Value = availableYear.ToString()
                                            });

            var selectedYear = year ?? availableYears.First();
            details.MalePopulation = statistics.GetMalePopulation(id, selectedYear);
            details.FemalePopulation = statistics.GetFemalePopulation(id, selectedYear);
            details.TotalPopulation = details.MalePopulation + details.FemalePopulation;

            return View(details);
        }

    }
}
