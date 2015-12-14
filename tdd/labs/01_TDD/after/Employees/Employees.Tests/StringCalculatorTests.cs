using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employees.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_Empty_String()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_Single_Number()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("4");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Add_Two_Numbers()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("4,8");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Works_With_Extra_Comma()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("4,,8");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Adds_Three_Numbers()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("4,,8,15");

            Assert.AreEqual(27, result);
        }
    }
}