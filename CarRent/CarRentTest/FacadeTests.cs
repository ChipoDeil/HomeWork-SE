using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;
using System.Collections.Generic;

namespace CarRentTest
{
    [TestClass]
    public class FacadeTests
    {
        [TestMethod]
        public void TryToRentCarForMoreThan60Days_IsItPossible()
        {
            //Arrange
            AdminFacade admin = new AdminFacade();
            UserFacade user = new UserFacade(admin.CarRentCenter);
            Car car = new Car("lada", "green", 1);
            admin.AddCar(car);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 12, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            bool result;
            //Act
            result = user.RentCar("lada", "green", "Bob", startDate, endDate);
            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TryToRentCarWithInvalidDates_IsItPossible()
        {
            //Arrange
            AdminFacade admin = new AdminFacade();
            UserFacade user = new UserFacade(admin.CarRentCenter);
            Car car = new Car("lada", "green", 1);
            admin.AddCar(car);
            DateTimeOffset startDate = new DateTimeOffset(2017, 12, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            bool result;
            //Act
            result = user.RentCar("lada", "green", "Bob", startDate, endDate);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToRentFreeCar_IsItPossible()
        {
            //Arrange
            AdminFacade admin = new AdminFacade();
            UserFacade user = new UserFacade(admin.CarRentCenter);
            Car car = new Car("lada", "green", 1);
            admin.AddCar(car);
            DateTimeOffset startDate = new DateTimeOffset(2017, 12, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            bool result;
            //Act
            result = user.RentCar("lada", "green", "Bob", startDate, endDate);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetArrayOfAvailableCarsForDates_IsItRight()
        {
            //Arrange
            AdminFacade admin = new AdminFacade();
            UserFacade user = new UserFacade(admin.CarRentCenter);

            Car car1 = new Car("lada", "green", 1);
            Car car2 = new Car("BMW", "black", 1);
            Car car3 = new Car("lada", "green", 1);

            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);

            admin.AddCar(car1);
            admin.AddCar(car2);
            admin.AddCar(car3);
            int expected = 2;
            List<string> result;
            //Act
            result = user.GetListOfAvailableCars(startDate, endDate, "Bob");
            //Assert
            Assert.AreEqual(result.Count, expected);
        }
    }
}
