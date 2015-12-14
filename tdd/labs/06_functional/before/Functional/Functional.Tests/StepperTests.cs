using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Tests
{
    [TestClass]
    public class StepperTests
    {
        [TestMethod]
        public void Stepping_Returns_True()
        {
            Stepper stepper = new Stepper();
            Assert.IsTrue(stepper.DoSteps());
        }
    }
}