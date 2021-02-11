using DesignCrowdTechChallenge.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesignCrowdTestChallenge.Test
{
    public class CalculateWeekDaysTest
    {

        [Theory]
        [MemberData(nameof(GetTotalHolidayTestCases))]
        public void WeekdaysBetweenTwoDatesTest(DateTime firstDate, DateTime secondDate, Action<int> assertion)
        {
            var _publicHolidayProvider = new PublicHolidayProvider();

            var businessDayCounter = new BusinessDayCounter(_publicHolidayProvider);

            var daysCount = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            assertion(daysCount);
        }

        public static IEnumerable<object[]> GetTotalHolidayTestCases
        {
            get
            {
                // TestCase1
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
                    assertion
                };

                // TestCase2
                DateTime startDateCase2 = new DateTime(2013, 10, 5);
                DateTime endDateCase2 = new DateTime(2013, 10, 14);
                Action<int> assertionCase2 = result =>
                {
                    result.Should().Be(5);
                };

                yield return new object[]
                {
                    startDateCase2,
                    endDateCase2,
                    assertionCase2
                };

                // TestCase3
                DateTime startDateCase3 = new DateTime(2013, 10, 7);
                DateTime endDateCase3 = new DateTime(2014, 01, 01); 

                Action<int> assertionCase3 = result =>
                {
                    result.Should().Be(61);
                };

                yield return new object[]
                {
                    startDateCase3,
                    endDateCase3,
                    assertionCase3
                };

                // TestCase4
                DateTime startDateCase4 = new DateTime(2013, 10, 7);
                DateTime endDateCase4 = new DateTime(2013, 10, 5);

                Action<int> assertionCase4 = result =>
                {
                    result.Should().Be(0);
                };

                yield return new object[]
                {
                    startDateCase4,
                    endDateCase4,
                    assertionCase4
                };
            }
        }
    }
}
