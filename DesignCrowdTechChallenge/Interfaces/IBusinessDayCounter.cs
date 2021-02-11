using System;
using System.Collections.Generic;

namespace DesignCrowdTechChallenge.Interfaces
{
    public interface IBusinessDayCounter
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IReadOnlyList<DateTime> publicHolidays);
    }
}
