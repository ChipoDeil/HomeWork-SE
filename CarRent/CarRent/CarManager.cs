using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class CarManager
    {
        public Dictionary<Car, List<Timing>> TimeSheetForCars { get; }

        public bool RentCar(string model, string color, Timing userTiming)
        {
            List<Car> listOfProperCars = FindAllCars(color, model);
            if (listOfProperCars.Count == 0)
                return false;
            for (int i = 0; i < listOfProperCars.Count; i++)
            {
                Car car = listOfProperCars.ElementAt(i);
                List<Timing> timeSheetForOneCar = TimeSheetForCars[car];
                if (timeSheetForOneCar.Count % 10 == 0 && timeSheetForOneCar.Count != 0)
                    SendToCheckUp(car);
                if (car.Сheckup != null)
                    if (car.Сheckup >= userTiming.StartDate)
                        continue;

                bool isItPossibleToRentACar = timeSheetForOneCar.All(x => x.IsNotIntersectWith(userTiming));

                if (isItPossibleToRentACar)
                {
                    timeSheetForOneCar.Add(userTiming);
                    TimeSheetForCars[car] = timeSheetForOneCar;
                    return isItPossibleToRentACar;
                }
            }

            return false;
            
        }

        public List<Car> GetListOfAvailableCars(Timing userTiming) {
            List<Car> availableCars = new List<Car>();
            for (int i = 0; i < TimeSheetForCars.Count; i++)
            {
                Car carLoc = TimeSheetForCars.ElementAt(i).Key;
                List<Timing> timeSheetForOneCar = TimeSheetForCars.ElementAt(i).Value;
                if (timeSheetForOneCar.Count % 10 == 0 && timeSheetForOneCar.Count != 0)
                    continue;
                if (timeSheetForOneCar.All(car => car.IsNotIntersectWith(userTiming)) &&
                    carLoc.Сheckup < userTiming.StartDate) {
                    availableCars.Add(carLoc);
                }
            }
            return availableCars;
        }

        public void AddCar(Car car)
        {
            List<Timing> list = new List<Timing>();
            TimeSheetForCars.Add(car, list);
        }

        public int GetCountOfCars() {
            return TimeSheetForCars.Count;
        }

        Car ReturnCarById(int id)
        {
            return TimeSheetForCars.SingleOrDefault(pair => pair.Key.Id == id).Key;
        }

        private List<Car> FindAllCars(string color, string model) {
            List<Car> listOfProperCars = new List<Car>();
            listOfProperCars = TimeSheetForCars.Select(car => car.Key).ToList();
            return listOfProperCars.FindAll(car => car.Color == color && car.Model == model);
        }
        private void SendToCheckUp(Car car)
        {
            List<Timing> sheetForCar = TimeSheetForCars[car];
            DateTimeOffset theLatest = sheetForCar.First().EndDate;
            for (int i = 0; i < sheetForCar.Count; i++)
            {
                if (theLatest < sheetForCar[i].EndDate)
                {
                    theLatest = sheetForCar[i].EndDate;
                }
            }
            theLatest = theLatest.AddDays(daysForCheckUp);
            car.Сheckup = theLatest;
        }

        public CarManager()
        {
            TimeSheetForCars = new Dictionary<Car, List<Timing>>();
        }

        
        const int daysForCheckUp = 10;
    }
}
