using System;
using System.Collections.Generic;

namespace DesignCrowdTechChallenge.Interfaces
{
    public interface IPublicHolidayProvider 
    {
        IReadOnlyList<DateTime> GetPublicHoliday(int year);
    }
}
