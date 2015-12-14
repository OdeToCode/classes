using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Models;

namespace Cars.Controllers
{
    public class CarController : Controller
    {
        //
        // GET: /Cars/

        public ActionResult Index()
        {
            string path = Server.MapPath("~/App_Data/cars.csv");
            var repository = new CarRepository(path);
            var manufacturers = repository.GetManufacturers();
            return View(manufacturers);            
        }

        public ActionResult Show(string manufacturer, string carModel)
        {
            var repository = new CarRepository(Server.MapPath("~/App_Data/cars.csv"));

            var cars =
                     repository.GetAll()
                               .Where(c => manufacturer == "*" ||
                                           manufacturer == c.Manufacturer)
                               .Where(c => carModel == "*" ||
                                           c.ModelName.StartsWith(carModel));
            return View(cars);
        }


    }
}
