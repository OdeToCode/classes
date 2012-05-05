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
        private IUnitOfWork _db;
        private IEmployeeRepository _employeeRepository;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
            _employeeRepository = _db.Employees;
        }

        public ActionResult Index()
        {
            var model = _employeeRepository.FindAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _employeeRepository.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _employeeRepository.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employee updatedEmployee)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.Update(updatedEmployee);
                _db.Commit();
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
                _employeeRepository.Add(newEmployee);
                _db.Commit();
                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _employeeRepository.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _employeeRepository.Delete(id);
            _db.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
