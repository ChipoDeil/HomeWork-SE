using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;
using System.Collections.Generic;

namespace CarRentTest
{
    [TestClass]
    public class CarManagerTests
    {
        [TestMethod]
        public void TryToRentFreeCar_IsCarFree()
        {
            //Arrange
            CarManager carManager = new CarManager();
            Car car = new Car("lada", "baklazan", carManager.GetCountOfCars() + 1);
            carManager.AddCar(car);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 28, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 11, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            carManager.RentCar("lada", "baklazan", timing);
            startDate = new DateTimeOffset(2017, 11, 7, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 11, 9, 0, 0, 0, DateTimeOffset.Now.Offset);
            timing = new Timing(startDate, endDate);
            bool result;
            //Act
            result = carManager.RentCar("lada", "baklazan", timing);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToRentBusyCar_IsCarBusy()
        {
            //Arrange
            CarManager carManager = new CarManager();
            Car car = new Car("lada", "baklazan", carManager.GetCountOfCars() + 1);
            carManager.AddCar(car);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 28, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 11, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            carManager.RentCar("lada", "baklazan", timing);
            startDate = new DateTimeOffset(2017, 11, 4, 0, 0, 0, DateTimeOffset.Now.Offset);
            endDate = new DateTimeOffset(2017, 11, 9, 0, 0, 0, DateTimeOffset.Now.Offset);
            timing = new Timing(startDate, endDate);
            bool result;
            //Act
            result = carManager.RentCar("lada", "baklazan", timing);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToRentCarDuringCheckUp_IsCarFree()
        {
            //Arrange
            CarManager carManager = new CarManager();
            Car car = new Car("lada", "baklazan", carManager.GetCountOfCars() + 1);
            carManager.AddCar(car);
            for (int i = 1; i < 11; i++)
            {
                DateTimeOffset startDateLoc = new DateTimeOffset(2017, 10, i, 0, 0, 0, DateTimeOffset.Now.Offset);
                DateTimeOffset endDateLoc = new DateTimeOffset(2017, 10, i, 0, 0, 0, DateTimeOffset.Now.Offset);
                Timing timingLoc = new Timing(startDateLoc, endDateLoc);
                carManager.RentCar("lada", "baklazan", timingLoc);
            }
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 12, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 20, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            bool result;
            //Act
            result = carManager.RentCar("lada", "baklazan", timing);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToRentCarAfterCheckUp_IsCarFree()
        {
            //Arrange
            CarManager carManager = new CarManager();
            Car car = new Car("lada", "baklazan", carManager.GetCountOfCars() + 1);
            carManager.AddCar(car);
            for (int i = 1; i < 11; i++)
            {
                DateTimeOffset startDateLoc = new DateTimeOffset(2017, 10, i, 0, 0, 0, DateTimeOffset.Now.Offset);
                DateTimeOffset endDateLoc = new DateTimeOffset(2017, 10, i, 0, 0, 0, DateTimeOffset.Now.Offset);
                Timing timingLoc = new Timing(startDateLoc, endDateLoc);
                carManager.RentCar("lada", "baklazan", timingLoc);
            }
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 21, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 22, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            bool result;
            //Act
            result = carManager.RentCar("lada", "baklazan", timing);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryToRentCarWhereAreTwoEqualCarsAndOneIsFree_IsCarFree()
        {
            //Arrange
            Car car1 = new Car("lada", "baklazan", 1);
            Car car2 = new Car("lada", "baklazan", 2);
            CarManager carManager = new CarManager();
            carManager.AddCar(car1);
            carManager.AddCar(car2);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            carManager.RentCar("lada", "baklazan", timing);
            bool result;
            //Act
            result = carManager.RentCar("lada", "baklazan", timing);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TryToRentCarWhereAreTwoEqualCarsAndTwoIsBusy_IsCarBusy()
        {
            //Arrange
            Car car1 = new Car("lada", "baklazan", 1);
            Car car2 = new Car("lada", "baklazan", 2);
            CarManager carManager = new CarManager();
            carManager.AddCar(car1);
            carManager.AddCar(car2);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            carManager.RentCar("lada", "baklazan", timing);
            carManager.RentCar("lada", "baklazan", timing);
            bool result;
            //Act
            result = carManager.RentCar("lada", "baklazan", timing);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetListOfAvailableCarsForDate_IsItRight()
        {
            //Arrange
            Car car1 = new Car("lada", "baklazan", 1);
            Car car2 = new Car("lada", "baklazan", 2);
            CarManager carManager = new CarManager();
            carManager.AddCar(car1);
            carManager.AddCar(car2);
            DateTimeOffset startDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, DateTimeOffset.Now.Offset);
            DateTimeOffset endDate = new DateTimeOffset(2017, 10, 15, 0, 0, 0, DateTimeOffset.Now.Offset);
            Timing timing = new Timing(startDate, endDate);
            carManager.RentCar("lada", "baklazan", timing);
            int expected = 1;
            List<Car> result;
            //Act
            result = carManager.GetListOfAvailableCars(timing);
            //Assert
            Assert.AreEqual(expected, result.Count);
        }

    }
}
