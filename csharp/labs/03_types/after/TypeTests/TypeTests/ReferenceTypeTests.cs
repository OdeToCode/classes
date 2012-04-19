using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeLogic;

namespace TypeTests
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void CanChangeArrayElement()
        {
            int[] values = {1, 2, 3};
            ArrayChanger changer = new ArrayChanger();
            changer.ChangeValues(values);

            // Assert.IsTrue(values[0] == 1);
             Assert.IsTrue(values[0] == 2);
        }

        [TestMethod]
        public void CanChangeRefArrayElement()
        {
            int[] values = { 1, 2, 3 };
            ArrayChanger changer = new ArrayChanger();
            changer.ChangeValues(ref values);

            // Assert.IsTrue(values[0] == 1);
            Assert.IsTrue(values[0] == 2);
        }

        [TestMethod]
        public void CanChangeArray()
        {
            int[] values = { 1, 2, 3 };
            ArrayChanger changer = new ArrayChanger();
            changer.ChangeArray(values);

             Assert.IsTrue(values[0] == 1);
            // Assert.IsTrue(values[0] == 4);
        }

        [TestMethod]
        public void CanChangeRefArray()
        {
            int[] values = { 1, 2, 3 };
            ArrayChanger changer = new ArrayChanger();
            changer.ChangeArray(ref values);

            // Assert.IsTrue(values[0] == 1);
            Assert.IsTrue(values[0] == 4);
        }

    }
}
