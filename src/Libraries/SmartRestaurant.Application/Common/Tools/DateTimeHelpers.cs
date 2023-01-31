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

        public static Boolean CheckAvailabiliteOfOrderDeliveryInCurrentTime(string openingTime,string closingTime)
        {
            var currentTimeString = System.DateTime.Now.ToString("HH:mm:ss"); 
            if (DateTime.Parse(openingTime + ":00") > DateTime.Parse(closingTime + ":00"))
            {
             if ((DateTime.Parse(currentTimeString) <= DateTime.Parse("23:59:00") && DateTime.Parse(currentTimeString) > DateTime.Parse(openingTime + ":00")) || (DateTime.Parse(currentTimeString) < DateTime.Parse(closingTime + ":00") && DateTime.Parse(currentTimeString) >= DateTime.Parse("00:00:00")))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                if (DateTime.Parse(currentTimeString) < DateTime.Parse(closingTime + ":00") && DateTime.Parse(currentTimeString) > DateTime.Parse(openingTime + ":00"))
                {

                    return false;
                }
                else
                {

                    return true;
                }
            }
        }
    }
}
