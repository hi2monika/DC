using DesignCrowdTechChallenge.Interfaces;
using DesignCrowdTechChallenge.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesignCrowdTechChallenge
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            var serivce = _serviceProvider.GetService<IBusinessDayCounter>();

            var startDate = GetDateFromUser("Start");
            var endDate = GetDateFromUser("End");

            if (startDate == null && endDate == null)
            {
                Console.Write($"Incorrect input. Exiting the Application");
                return;
            }

            Console.WriteLine($"Holiday Count: Start date : {startDate} , End date {endDate}, DayCount : {serivce.WeekdaysBetweenTwoDates(startDate.Value, endDate.Value)}");
            Console.ReadLine();
        }
        private static DateTime? GetDateFromUser(string input)
        {
            
            Console.Write($"Enter {input} date ");
            
            var ed = Console.ReadLine();
            Console.Clear();

            bool result = DateTime.TryParse(ed, out DateTime parsedResponse);
            while (!result)
            {
                GetDateFromUser(input);
            }
            return parsedResponse;
        }
        private static void RegisterServices()
        {
            var collection = new ServiceCollection();

            collection.AddSingleton<IBusinessDayCounter, BusinessDayCounter>();
            collection.AddSingleton<IPublicHolidayProvider, PublicHolidayProvider>();

            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}
