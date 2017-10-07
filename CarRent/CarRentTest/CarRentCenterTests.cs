using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;
using System.Collections.Generic;

namespace CarRentTest
{
    [TestClass]
    public class CarRentCenterTests
    {
        [TestMethod]
        public void TryToRentFreeCarForBusyUser_IsItPossible()
        {
            //Arrange
            CarRentCenter rentCenter = new CarRentCenter();

            Car car = new Car("lada", "baklazan", 1);
            Car car2 = new Car("lada", "baklazan", 2);
            Car car3 = new Car("lada", "baklazan", 3);

            rentCenter.AddNewCar(car);
            rentCenter.AddNewCar(car2);
            rentCenter.AddNewCar(car3);

            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 28, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 11, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);

            rentCenter.RentCar(car.Model, car.Color, startDate, endDate, "Bob");

            startDate = new DateTimeOffset(2017, 10, 28, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 11, 5, 0, 0, 0, DateTimeOffset.Now.Offset);

            bool result;
            //Act
            result = rentCenter.RentCar(car.Model, car.Color, startDate, endDate, "Bob");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToRentFreeCarForFreeUser_IsItPossible()
        {
            //Arrange
            CarRentCenter rentCenter = new CarRentCenter();
            Car car = new Car("lada", "baklazan", 1);
            rentCenter.AddNewCar(car);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            rentCenter.RentCar(car.Model, car.Color, startDate, endDate, "Bob");
            startDate = new DateTimeOffset(2017, 10, 18, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 10, 22, 0, 0, 0, DateTimeOffset.Now.Offset);
            bool result;
            //Act
            result = rentCenter.RentCar(car.Model, car.Color, startDate, endDate, "Bob");
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetListOfZeroCars_IsItEmpty()
        {
            //Arrange
            CarRentCenter rentCenter = new CarRentCenter();
            int expected = 0;
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            List<string> result;
            //Act
            result = rentCenter.GetInformationAboutAvailableCars(startDate, endDate, "123");
            //Assert
            Assert.AreEqual(expected,result.Count);
        }

        [TestMethod]
        public void GetListOfSomeCars_IsItRight()
        {
            //Arrange
            CarRentCenter rentCenter = new CarRentCenter();
            Car car1 = new Car("lada", "baklazan", 1);
            Car car2 = new Car("BMV", "baklazan", 2);
            rentCenter.AddNewCar(car1);
            rentCenter.AddNewCar(car2);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            List<string> result;
            int expected = 2;
            //Act
            result = rentCenter.GetInformationAboutAvailableCars(startDate, endDate, "123");
            //Assert
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void GetListOfSomeEqualCars_IsItRight()
        {
            //Arrange
            CarRentCenter rentCenter = new CarRentCenter();
            Car car1 = new Car("lada", "baklazan", 1);
            Car car2 = new Car("BMV", "baklazan", 2);
            Car car3 = new Car("BMV", "baklazan", 3);
            Car car4 = new Car("BMV", "baklazan", 3);
            rentCenter.AddNewCar(car1);
            rentCenter.AddNewCar(car2);
            rentCenter.AddNewCar(car3);
            rentCenter.AddNewCar(car4);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            List<string> result;
            int expected = 2;
            //Act
            result = rentCenter.GetInformationAboutAvailableCars(startDate, endDate, "123");
            //Assert
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void GetListOfSomeBusyCars_IsItRight()
        {
            //Arrange
            CarRentCenter rentCenter = new CarRentCenter();
            Car car1 = new Car("lada", "baklazan", 1);
            Car car2 = new Car("BMV", "baklazan", 2);
            Car car3 = new Car("BMV", "baklazan", 3);
            rentCenter.AddNewCar(car1);
            rentCenter.AddNewCar(car2);
            rentCenter.AddNewCar(car3);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 11, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            rentCenter.RentCar("BMV", "baklazan", startDate, endDate, "123123");
            rentCenter.RentCar("lada", "baklazan", startDate, endDate, "123123"); //he has already done this!
            List<string> result;
            int expected = 2;
            //Act
            result = rentCenter.GetInformationAboutAvailableCars(startDate, endDate, "123");
            //Assert
            Assert.AreEqual(expected, result.Count);
        }

    }
}
