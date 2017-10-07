using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class UserFacade
    {
        const int maxDays = 60;
        public bool RentCar(string carModel, string carColor, string userNickname, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            TimeSpan difference = endDate - startDate;
            if (difference.Days <= maxDays && startDate <= endDate) {
                return carRentCenter.RentCar(carModel, carColor, startDate, endDate, userNickname);
            }
            return false;
        }
        public List<string> GetListOfAvailableCars(DateTimeOffset startDate, DateTimeOffset endDate, string userNickname) {
            return carRentCenter.GetInformationAboutAvailableCars(startDate, endDate, userNickname);
        }

        public UserFacade(CarRentCenter carRentCenter)
        {
            this.carRentCenter = carRentCenter;
        }
        CarRentCenter carRentCenter;
    }
}
