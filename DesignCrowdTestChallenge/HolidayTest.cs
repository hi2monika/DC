using DesignCrowdTechChallenge.Models;
using FluentAssertions;
using System;
using Xunit;

namespace DesignCrowdTestChallenge.Helper
{
    public class MovableDateHolidayTest
    {
        [Fact]
        public void MovableHolidayTest()
        {
            var queensBirthday = new MovableDateHoliday(6, 2, DayOfWeek.Monday);
            var observedDate = queensBirthday.GetObservedDate(2021);

            var expectedDate = new DateTime(2021, 06, 14);

            observedDate.Should().Be(expectedDate);

        }
        [Fact]
        public void AdjustableHolidayTest()
        {
            var newYearsHoliday = new AdjustableDateHoliday(1,1);
            var observedDate = newYearsHoliday.GetObservedDate(2022);

            var expectedDate = new DateTime(2022, 01, 03);

            observedDate.Should().Be(expectedDate);

        }

        [Fact]
        public void FixedDateHolidayTest()
        {
            var fixedHoliday = new FixedDateHoliday(1, 05);
            var observedDate = fixedHoliday.GetObservedDate(2022);

            var expectedDate = new DateTime(2022, 01, 05);

            observedDate.Should().Be(expectedDate);

        }
    }
}
