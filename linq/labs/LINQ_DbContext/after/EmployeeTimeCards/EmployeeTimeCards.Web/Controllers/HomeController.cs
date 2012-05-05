using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeTimeCards.Core;
using EmployeeTimeCards.Web.Infrastructure;

namespace EmployeeTimeCards.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new TimeCardContext();
            var model = db.Employees;

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var db = new TimeCardContext();
            var model = db.Employees.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new TimeCardContext();
            var model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employee updatedEmployee)
        {
            if(ModelState.IsValid)
            {
                var db = new TimeCardContext();
                db.Entry(updatedEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedEmployee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee newEmployee)
        {
            if(ModelState.IsValid)
            {
                var db = new TimeCardContext();
                db.Employees.Add(newEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new TimeCardContext();
            var model = db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var db = new TimeCardContext();
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
