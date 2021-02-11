using System;

namespace DesignCrowdTechChallenge
{
    public static class HolidayHelper
    {
        public static DateTime FindDateForDayOfWeek(DateTime hol, DayOfWeek day)
        {
            while (hol.DayOfWeek != day)
                hol = hol.AddDays(1);

            return hol;
        }
        public static DateTime GetNextWorkingDay(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            else if (hol.DayOfWeek == DayOfWeek.Saturday)
                hol = hol.AddDays(2);
            return hol;
        }
    }
}
