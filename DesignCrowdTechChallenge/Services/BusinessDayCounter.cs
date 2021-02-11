using DesignCrowdTechChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCrowdTechChallenge.Services
{
    public class BusinessDayCounter : IBusinessDayCounter
    {
        private readonly IPublicHolidayProvider _publicHolidayProvider;
        public BusinessDayCounter(IPublicHolidayProvider publicHolidayProvider)
        {
            _publicHolidayProvider = publicHolidayProvider;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IReadOnlyList<DateTime> publicHolidays)
        {
            if (firstDate > secondDate)
            {
                return 0;
            }

            firstDate = firstDate.AddDays(1);
            var dayDifference = (int)secondDate.Subtract(firstDate).TotalDays;
            return Enumerable
                   .Range(0, dayDifference)
                   .Select(x => firstDate.AddDays(x))
                   .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday
                    && !publicHolidays.Contains(x.Date)
                   );
        }

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var publicHolidays = _publicHolidayProvider.GetPublicHoliday(firstDate.Year);
            return BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);
        }
    }
}
