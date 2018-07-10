using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oregon.Models;
using System;
using System.Collections.Generic;

namespace Oregon.Tests
{
    [TestClass]
    public class PlacesTests : IDisposable
    {
        public void Dispose()
        {
            Places.DeleteAll();
        }

        public PlacesTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=places;";
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            int result = Places.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfIDsAreTheSame_Place()
        {
            Places firstPlace = new Places(1, "Starbucks", "123 Fake St.", "Coffee Shop", "8", "8", "97202");
            Places secondPlace = new Places(2, "Starbucks", "123 Fake St.", "Coffee Shop", "6", "7", "97219");

            Assert.AreEqual(firstPlace, secondPlace);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ItemList()
        {
            Places testPlace = new Places(1, "Starbucks", "123 Fake St.", "Coffee Shop", "8", "8", "97202");

            testPlace.Save();
            List<Places> result = Places.GetAll();
            List<Places> testList = new List<Places> { testPlace };

            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Places testPlace = new Places(1, "Starbucks", "123 Fake St.", "Coffee Shop", "8", "8", "97202");

            testPlace.Save();
            Places savedPlace = Places.GetAll()[0];

            int result = savedPlace.GetId();
            int testId = testPlace.GetId();

            Assert.AreEqual(testId, result);
        }
    }
}
