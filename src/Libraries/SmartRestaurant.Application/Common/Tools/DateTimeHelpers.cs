using System;

namespace SmartRestaurant.Application.Common.Tools
{
    public class DateTimeHelpers
    {
        public static DateTime GetLastMonth(DateTime dateTime)
        {
            var lastMonth = dateTime.AddMonths(-1);
            return new DateTime(lastMonth.Year, lastMonth.Month, 1);
        }
    }
}
