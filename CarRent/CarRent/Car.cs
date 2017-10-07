using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Car
    {

        public Car(string model, string color, int id)
        {
            Model = model;
            Color = color;
            Id = id;

        }

        public string Model { get; }

        public string Color { get; }

        public int Id { get; }

        public DateTimeOffset Сheckup { get; set; } // date of ending new CheckUp

    }
}
