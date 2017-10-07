using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class User
    {
        public User(string nickname) {
            Nickname = nickname;
            DatesOfRenting = new List<Timing>();
        }

        public void AddRentInformation(Timing timingOfUser) {
            DatesOfRenting.Add(timingOfUser);
        }

        public bool IsPeriodFree(Timing timing){
            return DatesOfRenting.All(x => x.IsNotIntersectWith(timing));
        }
        
        public string Nickname { get; }
        public List<Timing> DatesOfRenting { get; }
        
    }
}
