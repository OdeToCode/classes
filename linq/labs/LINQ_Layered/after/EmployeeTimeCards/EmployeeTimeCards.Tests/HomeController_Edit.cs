using System.Web.Mvc;
using EmployeeTimeCards.Core;
using EmployeeTimeCards.Web.Controllers;
using EmployeeTimeCards.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTimeCards.Tests
{
    [TestClass]
    public class HomeController_Edit
    {
        private FakeUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = new FakeUnitOfWork();
            _unitOfWork.Employees = new FakeEmployeeRepository();
            _unitOfWork.Employees.Add(new Employee() { Id = 1 });
            _unitOfWork.Employees.Add(new Employee() { Id = 2 });
            _unitOfWork.Employees.Add(new Employee() { Id = 3 });
        }

        [TestMethod]
        public void Returns_Correct_Model_On_Edit_Get()
        {
            var controller = new HomeController(_unitOfWork);

            var result = controller.Edit(2);
            var model = ((ViewResult) result).Model as Employee;

            Assert.AreEqual(2, model.Id);
        }

        [TestMethod]
        public void Commits_When_Edit_Succesfull()
        {
            var controller = new HomeController(_unitOfWork);
            var employeeToEdit = _unitOfWork.Employees.Find(1);

            controller.Edit(employeeToEdit);

            Assert.IsTrue(_unitOfWork.Committed);
        }

        [TestMethod]
        public void Does_Not_Commit_When_ModelState_Invalid()
        {
            var controller = new HomeController(_unitOfWork);
            var employeeToEdit = _unitOfWork.Employees.Find(1);
            controller.ModelState.AddModelError("", "");

            controller.Edit(employeeToEdit);

            Assert.IsFalse(_unitOfWork.Committed);
        }
    }
}