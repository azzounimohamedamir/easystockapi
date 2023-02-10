using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Interfaces;
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

        public static ErrorResult CheckAvailabiliteOfOrderDeliveryInCurrentTime(string openingTime,string closingTime ,IDateTime datetime)
        {
            var currentTimeString = datetime.Now().ToString("HH:mm:ss"); 

            if(openingTime == null || closingTime == null) {
                return ErrorResult.None;
            }
            else
            {
                if (DateTime.Parse(openingTime + ":00") > DateTime.Parse(closingTime + ":00"))
                {
                    if ((DateTime.Parse(currentTimeString) <= DateTime.Parse("23:59:00") && DateTime.Parse(currentTimeString) > DateTime.Parse(openingTime + ":00")) || (DateTime.Parse(currentTimeString) < DateTime.Parse(closingTime + ":00") && DateTime.Parse(currentTimeString) >= DateTime.Parse("00:00:00")))
                    {
                       return ErrorResult.None;
                    }
                    else
                    {
                        return ErrorResult.OutOfDeliveryTime;
                    }
                }
                else
                {

                    if (DateTime.Parse(currentTimeString) < DateTime.Parse(closingTime + ":00") && DateTime.Parse(currentTimeString) > DateTime.Parse(openingTime + ":00"))
                    {

                        return ErrorResult.None;
                    }
                    else
                    {

                        return ErrorResult.OutOfDeliveryTime;
                    }
                }
            }
            
        }
    }
}
