using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GovData;
using System.Collections.Generic;

namespace GovDataUnitTests
{
    /// <summary>
    /// This test class does some simple tests to determine if you have implemented the 
    /// IListElectedCongress correctly. 
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        List<Type> list;

        public UnitTests()
        {
            list = Utilities.GetTypeImplementing(typeof(IListElectedCongress));
        }

        [TestMethod]
        public void ImplementedInterfaceTest()
        {
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void CheckZip()
        {
            foreach (Type type in list)
            {
                //Create an instance of an object that implements the Interface
                IListElectedCongress testTypeInstance = (IListElectedCongress)Activator.CreateInstance(type);
                //Set the API Code here (you know the one for Bing Maps)
                testTypeInstance.SetApiCode("Aq9kZuBvs2QT_YQeG5kYXejUqD0rLAsQkjgqZJzbIyANUGZbquKQ4xF02cHByqMk");

                //This test was initially == null... But GetRepByZip should never return null... those are valid Zip codes. So I changed the test to != null!
                //37353 is Mc Donald in Bradley county
                //37315 is Collegedale in Hamilton county
                Assert.IsTrue(testTypeInstance.GetRepresentativesByZip("37353") != null);
                Assert.IsTrue(testTypeInstance.GetRepresentativesByZip("37315") != null);
            }
        }

        [TestMethod]
        public void CheckAddress()
        {
            foreach (Type type in list)
            {
                //Create an instance of an object that implements the Interface
                IListElectedCongress testTypeInstance = (IListElectedCongress)Activator.CreateInstance(type);
                //Set the API Code here (you know the one for Bing Maps)
                testTypeInstance.SetApiCode("Aq9kZuBvs2QT_YQeG5kYXejUqD0rLAsQkjgqZJzbIyANUGZbquKQ4xF02cHByqMk");
                var collegedale = testTypeInstance.GetRepresentativesByAddress("5110 University Drive", "Collegedale", "TN", "37315");
                Assert.IsTrue(collegedale != null);
                Assert.IsTrue(collegedale[0].BioguideID.Equals("F000459"));
            }
        }

        [TestMethod]
        public void CheckSenZip()
        {
            foreach (Type type in list)
            {
                //Create an instance of an object that implements the Interface
                IListElectedCongress testTypeInstance = (IListElectedCongress)Activator.CreateInstance(type);
                //Set the API Code here (you know the one for Bing Maps)
                testTypeInstance.SetApiCode("Aq9kZuBvs2QT_YQeG5kYXejUqD0rLAsQkjgqZJzbIyANUGZbquKQ4xF02cHByqMk");
                var collegedale = testTypeInstance.GetSenator("TN");
                Assert.IsTrue(testTypeInstance.GetRepresentativesByZip("37353") != null);
                Assert.IsTrue(testTypeInstance.GetRepresentativesByZip("37315") != null);
                Assert.IsTrue(collegedale[0].bioguide_id.Equals("A000360"));
            }
        }
    }
}
