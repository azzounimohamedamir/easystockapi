using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.IntegrationTests
{
    public class DateTimeServiceMocked : IDateTime
    {
        public DateTime DateTime { get; set; }
        public DateTime Now()
        {
            return DateTime;
        }

        public void SetDateTimeNow(DateTime dateTime)
        {
            DateTime = dateTime;
        }
    }
}
