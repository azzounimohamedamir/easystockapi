using SmartRestaurant.Application.Common.Enums;
using System;

namespace SmartRestaurant.Application.Common.Tools
{
    public class FiltersHelpers
    {
        public static DateTime GetDateFilter(DateFilter dateFilter)
        {
            var now = DateTime.Now;
            var firstDay = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            switch (dateFilter)
            {
                case DateFilter.ToDay:
                    return firstDay;

                case DateFilter.Last7Days:
                    return firstDay.AddDays(-7);

                case DateFilter.Last30Days:
                    return firstDay.AddDays(-30);

                case DateFilter.All:
                    return firstDay.AddYears(-30);

                default:
                    return firstDay;
            }
        }
    }
}
