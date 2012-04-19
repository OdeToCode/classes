using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Test
{
    [TestClass]
    public class FinderTests
    {
        [TestMethod]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new PersonList();
            var finder = new ClosestFinder(list);

            var result = finder.Find();

            Assert.IsNull(result.Person1);
            Assert.IsNull(result.Person2);
        }

        [TestMethod]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new PersonList { sue };
            var finder = new ClosestFinder(list);

            var result = finder.Find();

            Assert.IsNull(result.Person1);
            Assert.IsNull(result.Person2);
        }

        [TestMethod]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new PersonList { sue, greg };
            var finder = new ClosestFinder(list);

            var result = finder.Find();

            Assert.AreSame(sue, result.Person1);
            Assert.AreSame(greg, result.Person2);
        }

        [TestMethod]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new PersonList { greg, mike };
            var finder = new FurthestFinder(list);

            var result = finder.Find();

            Assert.AreSame(greg, result.Person1);
            Assert.AreSame(mike, result.Person2);
        }

        [TestMethod]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new PersonList { greg, mike, sarah, sue };
            var finder = new FurthestFinder(list);

            var result = finder.Find();

            Assert.AreSame(sue, result.Person1);
            Assert.AreSame(sarah, result.Person2);
        }

        [TestMethod]
        public void Returns_Closest_Birthdays_For_Four_People()
        {
            var list = new PersonList { greg, mike, sarah, sue };
            var finder = new ClosestFinder(list);

            var result = finder.Find();

            Assert.AreSame(sue, result.Person1);
            Assert.AreSame(greg, result.Person2);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}