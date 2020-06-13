using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Exceptions
{
    class NotAuthorisedException:Exception
    {
        public NotAuthorisedException() : base()
        {

        }
        public NotAuthorisedException(string message) : base(message)
        {

        }
    }
}
