using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employees.Tests
{
    [TestClass]
    public class EmployeeTests
    {                 
        [TestMethod]         
        public void Formats_LastName_FirstName()
        {
            var employee = new Employee();
            employee.FirstName = "Scott";
            employee.LastName = "Allen";

            var result = employee.FormatName();
            var resultAsArray = result.ToCharArray();
            var expectedArray = "Allen, Scott".ToCharArray();
            
            Assert.IsTrue(expectedArray.SequenceEqual(resultAsArray));
        }  

        [TestMethod]
        public void Can_Give_Employee_Raise()
        {
            var employee = new Employee();
            employee.Salary = 10.0;
            employee.GiveRaise(0.3333);            

            Assert.AreEqual(13.333, employee.Salary, 0.0001);
        }     
        
  
        [TestMethod]
        public void Initial_Name_Values_Are_Empty_Strings()
        {
            var employee = new Employee();

            Assert.AreEqual(employee.FirstName, string.Empty);
            Assert.AreEqual(employee.LastName, string.Empty);
        }

        [TestMethod]
        public void Format_Empty_Name_Returns_Empty_String()
        {
            var employee = new Employee();

            var result = employee.FormatName();

            Assert.AreEqual(result, string.Empty);
        }
    }
}