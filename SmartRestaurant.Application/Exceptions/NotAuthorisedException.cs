using System;

namespace SmartRestaurant.Application.Exceptions
{
    class NotAuthorisedException : Exception
    {
        public NotAuthorisedException() : base()
        {

        }
        public NotAuthorisedException(string message) : base(message)
        {

        }
    }
}
