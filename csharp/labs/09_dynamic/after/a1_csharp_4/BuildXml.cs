using System;
using System.Collections;
using System.Dynamic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace a1_csharp_4
{
    [TestClass]
    public class BuildXml
    {
        //[TestMethod]
        //public void Step1_CanLoadXml()
        //{
        //    var dynamicXml = DynamicXml.Parse(xml);
        //    Assert.IsTrue(dynamicXml is DynamicObject);
        //}

        //[TestMethod]
        //public void Step2_CanAccessPeople()
        //{
        //    var dynamicXml = DynamicXml.Parse(xml);
        //    var people = dynamicXml.People;
        //    Assert.IsNotNull(people);
        //}


        //[TestMethod]
        //public void Step3_CanIterateAllFourPeople()
        //{
        //    var dynamicXml = DynamicXml.Parse(xml);
        //    var people = dynamicXml.People;

        //    int count = 0;
        //    foreach (var person in people)
        //    {
        //        count++;
        //    }

        //    Assert.AreEqual(4, count);
        //}

        //[TestMethod]
        //public void Step4_CanGetPersonsName()
        //{
        //    string[] names = { "John", "David", "Scott", "Fritz" };

        //    var dynamicXml = DynamicXml.Parse(xml);
        //    var people = dynamicXml.People;

        //    int i = 0;
        //    foreach (var person in people)
        //    {
        //        Assert.AreEqual(names[i++], person.Name);
        //    }
        //}	

        private string xml =
            @"<People>
                <Person Name=""John""/>
                <Person Name=""David""/>
                <Person Name=""Scott""/>
                <Person Name=""Fritz""/>
              </People>";
    }
}
