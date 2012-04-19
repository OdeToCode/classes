using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeLogic;

namespace TypeTests
{
    [TestClass]
    public class ValueTypeTests
    {
        [TestMethod]
        public void CanChangeIntParameter()
        {
            int x = 10;
            IntChanger changer = new IntChanger();
            changer.Change(x);

            Assert.IsTrue(x == 10);
            // Assert.IsTrue(x == 11);
        }

        [TestMethod]
        public void CanChangeRefIntParameter()
        {
            int x = 10;
            IntChanger changer = new IntChanger();
            changer.Change(ref x);

            // Assert.IsTrue(x == 10);
            Assert.IsTrue(x == 11);
        }
    }
}
