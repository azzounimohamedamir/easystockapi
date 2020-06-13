using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException():base()
        {

        }
        public NotFoundException(string message):base(message)
        {

        }
    }
}
