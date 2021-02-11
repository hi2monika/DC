using System;

namespace DesignCrowdTechChallenge.Models
{
    public abstract class BaseHoliday
    {
        public abstract DateTime GetObservedDate(int year);
    }
}
