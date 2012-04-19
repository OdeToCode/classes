using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderProcessing.Tests
{
    [TestClass]
    public class OrderProcessorTests
    {
        private OrderProcessor _processor;
        private FakeOrderDataAccess _orderDataAccess;
        private FakeLogger _fakeLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            _orderDataAccess = new FakeOrderDataAccess();
            _fakeLogger = new FakeLogger();
            _processor = new OrderProcessor(_orderDataAccess, _fakeLogger);
        }

        [TestMethod]
        public void Records_Correct_Ship_Date()
        {
            SystemTime.Now = () => new DateTime(2008, 6, 1);
            var order = new Order() { Origin = "MD", Destination = "WA" };

            _processor.ShipOrder(order);

            Assert.AreEqual(SystemTime.Now(), order.ShipDate);
            
        }

        [TestMethod]
        public void Logs_Message_When_Processing()
        {
            var order = new Order() { Origin = "MD", Destination = "WA" };

            _processor.ShipOrder(order);

            Assert.IsTrue(_fakeLogger.LogMessages[0].Contains("Order"));
        }

        [TestMethod]
        public void SavesAValidOrder()
        {
            var order = new Order() { Origin = "MD", Destination="WA" };

            _processor.ShipOrder(order);

            Assert.AreSame(order, _orderDataAccess.SavedOrders[0]);
        }

        [TestMethod]
        public void DoesNotSaveAnInvalidOrder()
        {
            var order = new Order() { Origin = "MD", Destination = "" };

            try
            {
                _processor.ShipOrder(order);
            }
            catch(ArgumentException){}

            Assert.AreEqual(0, _orderDataAccess.SavedOrders.Count);
        }
    }
}