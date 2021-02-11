using System;

namespace DesignCrowdTechChallenge.Models
{
    //Year's Day on January 1st every year, unless that is a Saturday or Sunday, in which case the    holiday is the next Monday.
    public class AdjustableDateHoliday : BaseHoliday
    {
        private int _month;
        private int _day;
        public AdjustableDateHoliday(int month, int day)
        {
            //TODO validation for the incorrect Param
            _month = month;
            _day = day;
        }
        public override DateTime GetObservedDate(int year)
        {
            var holidayDate = new DateTime(year, _month, _day);
            return HolidayHelper.GetNextWorkingDay(holidayDate);
        }
    }
}
