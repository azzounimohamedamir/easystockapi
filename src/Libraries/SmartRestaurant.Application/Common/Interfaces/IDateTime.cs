using System;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IDateTime
    {
        public void SetDateTimeNow(DateTime dateTime);
        public DateTime Now();
    }
}
