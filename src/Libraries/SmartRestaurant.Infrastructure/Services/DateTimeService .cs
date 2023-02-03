using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
