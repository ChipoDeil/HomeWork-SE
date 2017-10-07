using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CarRent
{
    public class CarRentCenter
    {

        public bool RentCar(string model, string color, DateTimeOffset startTime, DateTimeOffset endTime, string nickname)
        {
            Timing requestedTiming = new Timing(startTime, endTime);
            if (IsItPossibleToRentCarForUser(nickname, requestedTiming))
                if (carManager.RentCar(model, color, requestedTiming)) {
                    AddRentInformationToUser(nickname, requestedTiming);
                    return true;
                }

            return false;
        }

        public List<string> GetInformationAboutAvailableCars(DateTimeOffset startTime, DateTimeOffset endTime, string nickname) {
            Timing requestedTiming = new Timing(startTime, endTime);
            if (IsItPossibleToRentCarForUser(nickname, requestedTiming)) {
                List<Car> availableCars = carManager.GetListOfAvailableCars(requestedTiming);
                return TransformListOfCarsToStringArray(availableCars);
            }
            return default(List<string>);
        }


        public void AddNewCar(Car car) {
            carManager.AddCar(car);
        }
        private List<string> TransformListOfCarsToStringArray(List<Car> availableCars)
        {
            List<string> availableCarsStringArray = new List<string>();
            for (int i = 0; i < availableCars.Count; i++)
            {
                string stringToAdd = availableCars.ElementAt(i).Model + " " + availableCars.ElementAt(i).Color;
                if (availableCarsStringArray.All(obj => !obj.Equals(stringToAdd)))
                    availableCarsStringArray.Add(stringToAdd);

            }
            return availableCarsStringArray;
        }

        private bool IsItPossibleToRentCarForUser(string nickname, Timing requestedTiming)
        {
            if (!DoesUserExist(nickname))
                CreateNewUser(nickname);
            User currentUser = listOfUsers.Find(x => x.Nickname.Equals(nickname));
            return currentUser.IsPeriodFree(requestedTiming);
        }

        private bool DoesUserExist(string nickname)
        {
            return listOfUsers.Find(x => x.Nickname.Equals(nickname)) != null;
        }

        private void CreateNewUser(string nickname)
        {
            listOfUsers.Add(new User(nickname));
        }

        private List<User> GetInformationAboutUsers()
        {
            return listOfUsers;
        }

        private void AddRentInformationToUser(string nickname, Timing userTiming) {
            User currentUser = listOfUsers.Find(x => x.Nickname.Equals(nickname));
            currentUser.AddRentInformation(userTiming);
        }
        
        public CarRentCenter() {
            listOfUsers = new List<User>();
            carManager = new CarManager();
        }

        List<User> listOfUsers;
        CarManager carManager;
    }
}
