using SmartRestaurant.Application.Common.Interfaces;
using System;

namespace SmartRestaurant.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public void SetDateTimeNow(DateTime dateTime)
        {

        }
    }
}
