using DesignCrowdTechChallenge.Interfaces;
using DesignCrowdTechChallenge.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesignCrowdTestChallenge.Test
{
    public class BuinessDayCounterTest
    {
        [Theory]
        [MemberData(nameof(GetTotalHolidayTestCases))]
        public void BusinessDaysBetweenTwoDatesTest(DateTime firstDate, DateTime secondDate, IReadOnlyList<DateTime> publicHolidays,
          Action<int> assertion)
        {
            var _publicHolidayProvider = new Mock<IPublicHolidayProvider>();
            
            var businessDayCounter = new BusinessDayCounter(_publicHolidayProvider.Object);

            var daysCount = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);
            
            assertion(daysCount);
        }

        public static IEnumerable<object[]> GetTotalHolidayTestCases
        {
            get
            {
                var holidays = new List<DateTime>() {
                                                    new DateTime(2013, 12, 25),
                                                    new DateTime(2013, 12, 26),
                                                    new DateTime(2014, 01, 01)
                                                };

                DateTime startDateCase1 = new DateTime(2013, 10, 7);
                DateTime endDateCase1 = new DateTime(2013, 10, 09); 
                Action<int> assertion = result =>
                {                    
                    result.Should().Be(1);
                };

                yield return new object[]
                {
                    startDateCase1,
                    endDateCase1,
                    holidays,
                    assertion
                };

                DateTime startDateCase2 = new DateTime(2013, 12, 24);
                DateTime endDateCase2 = new DateTime(2013, 12, 27);
                Action<int> assertionCase2 = result =>
                {
                    result.Should().Be(0);
                };

                yield return new object[]
                {
                    startDateCase2,
                    endDateCase2,
                    holidays,
                    assertionCase2
                };

                DateTime startDateCase3 = new DateTime(2013, 10, 07);
                DateTime endDateCase3 = new DateTime(2014, 01, 01); 

                Action<int> assertionCase3 = result =>
                {
                    result.Should().Be(59);
                };

                yield return new object[]
                {
                    startDateCase3,
                    endDateCase3,
                    holidays,
                    assertionCase3
                };

            }
        }

    }
}
