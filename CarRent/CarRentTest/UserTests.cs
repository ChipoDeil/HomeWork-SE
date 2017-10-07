using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;
using System.Collections.Generic;

namespace CarRentTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void AddToUserRentInformation_HasInformationAdded()
        {
            //Arrange
            User user = new User("Yaroslav");
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 06, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 07, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            List<Timing> expected = new List<Timing>();
            expected.Add(timing);
            //Act
            user.AddRentInformation(timing);
            //Assert
            CollectionAssert.AreEqual(expected, user.DatesOfRenting);
        }

        [TestMethod]
        public void TryToRentCarForBusyUser_IsUserBusy(){
            //Arrange
            User user = new User("Yaroslav");
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 28, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 11, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            user.AddRentInformation(timing);
            startDate = new DateTimeOffset(2017, 10, 2, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            timing = new Timing(startDate, endDate);
            user.AddRentInformation(timing);
            startDate = new DateTimeOffset(2017, 10, 4, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 10, 10, 0, 0, 0, DateTimeOffset.Now.Offset);
            timing = new Timing(startDate, endDate);
            bool result;
            //Act
            result = user.IsPeriodFree(timing);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToRentCarForFreeUser_IsUserFree()
        {
            //Arrange
            User user = new User("Yaroslav");
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 28, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 11, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            user.AddRentInformation(timing);
            startDate = new DateTimeOffset(2017, 10, 2, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            timing = new Timing(startDate, endDate);
            user.AddRentInformation(timing);
            startDate = new DateTimeOffset(2017, 10, 7, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 10, 12, 0, 0, 0, DateTimeOffset.Now.Offset);
            timing = new Timing(startDate, endDate);
            bool result;
            //Act
            result = user.IsPeriodFree(timing);
            //Assert
            Assert.IsTrue(result);
        }

    }
}
