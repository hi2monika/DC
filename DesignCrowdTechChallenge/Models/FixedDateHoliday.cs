using System;

namespace DesignCrowdTechChallenge.Models
{
    //- Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year
    public class FixedDateHoliday : BaseHoliday
    {
        private int _month;
        private int _day;
        public FixedDateHoliday(int month, int day)
        {
            //TODO validation for the incorrect Param
            _month = month;
            _day = day;
        }
        public override DateTime GetObservedDate(int year)
        {
            var holidayDate = new DateTime(year, _month, _day);
            return holidayDate;
        }
    }
}
