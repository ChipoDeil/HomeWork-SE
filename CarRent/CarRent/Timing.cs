using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Timing
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public Timing(DateTimeOffset startDate, DateTimeOffset endDate) {
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsNotIntersectWith(Timing otherTiming)
        {
            bool leftSideCondition = StartDate > otherTiming.EndDate && StartDate > otherTiming.StartDate;
            bool rightSideCondition = EndDate < otherTiming.StartDate && EndDate < otherTiming.EndDate;
            return leftSideCondition || rightSideCondition;
        }
    }
}
