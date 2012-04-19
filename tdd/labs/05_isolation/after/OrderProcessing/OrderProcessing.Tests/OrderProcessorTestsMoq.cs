using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace OrderProcessing.Tests
{
    [TestClass]
    public class OrderProcessorTestsMoq
    {
        private OrderProcessor _processor;
        private Mock<IOrderDataAccess> _mockDataAccess;
        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDataAccess = new Mock<IOrderDataAccess>();
            _mockLogger = new Mock<ILogger>();
            _processor = new OrderProcessor(_mockDataAccess.Object, _mockLogger.Object);
        }

        [TestMethod]
        public void Logs_Message_When_Processing()
        {
            var order = new Order() { Origin = "MD", Destination = "WA" };
            string logMessage = null;
            _mockLogger.Setup(l => l.Log(It.IsAny<string>()))
                       .Callback((string message) => logMessage = message);

            _processor.ShipOrder(order);

            Assert.IsTrue(logMessage.Contains("Order"));
        }

        [TestMethod]
        public void SavesAValidOrder()
        {
            var order = new Order() { Origin = "MD", Destination = "WA" };
            _mockDataAccess.Setup(dal => dal.SaveOrder(order));

            _processor.ShipOrder(order);

            _mockDataAccess.VerifyAll();
        }
    }
}