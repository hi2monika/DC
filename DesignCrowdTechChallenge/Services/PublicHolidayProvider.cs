using DesignCrowdTechChallenge.Interfaces;
using DesignCrowdTechChallenge.Models;
using System;
using System.Collections.Generic;

namespace DesignCrowdTechChallenge.Services
{
    public class PublicHolidayProvider : IPublicHolidayProvider
    {
        private IReadOnlyList<BaseHoliday> _publicHolidays;
        public PublicHolidayProvider()
        {
            var newYearDay = new AdjustableDateHoliday(1, 1);
            var australiaDay = new AdjustableDateHoliday(1, 26);
            var Azec = new FixedDateHoliday(5, 25);
            var queensBirthday = new MovableDateHoliday(6, 2, DayOfWeek.Monday);

            _publicHolidays = new List<BaseHoliday> {
                                                    newYearDay,
                                                    australiaDay,
                                                    Azec,
                                                    queensBirthday
                                                   };
        }
        public IReadOnlyList<DateTime> GetPublicHoliday(int year)
        {
            var holidays = new List<DateTime>();
            foreach (var publicHoliday in _publicHolidays)
            {
                holidays.Add(publicHoliday.GetObservedDate(year));

            }
            return holidays;
        }
    }
}
