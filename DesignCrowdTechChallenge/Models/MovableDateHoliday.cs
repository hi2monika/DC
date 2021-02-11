using System;

namespace DesignCrowdTechChallenge.Models
{
    //- Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the second Monday in June every year.
    public class MovableDateHoliday : BaseHoliday
    {
        private int _month;
        private int _week;
        private DayOfWeek _dayOfWeek;
        public MovableDateHoliday(int month, int week, DayOfWeek dayOfWeek)
        {
            //TODO validation for the incorrect Param
            _month = month;
            _week = week;
            _dayOfWeek = dayOfWeek;
        }
        public override DateTime GetObservedDate(int year)
        {
            var firstDayOfMonth = new DateTime(year, _month, 01);
            var noOfdaysToAdd = (_week - 1) * 7;
            var holiday = HolidayHelper.FindDateForDayOfWeek(firstDayOfMonth, _dayOfWeek).AddDays(noOfdaysToAdd);
            return holiday;
        }
    }
}
