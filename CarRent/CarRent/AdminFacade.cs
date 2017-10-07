using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class AdminFacade
    {
        public CarRentCenter CarRentCenter { get; }

        public AdminFacade()
        {
            CarRentCenter = new CarRentCenter();
        }

        public void AddCar(Car car) {
            CarRentCenter.AddNewCar(car);
        }

        public Dictionary<Car, List<Timing>> GetInformationAboutCars() {
            return default(Dictionary<Car, List<Timing>>);
        }


        /*public void SaveData() {

        }*/

    }
}
