using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Exceptions
{
    public class NotValidOperation : Exception
    {
        public NotValidOperation()
        {

        }
        public NotValidOperation(string message, Exception innerExcepsion = null) 
            : base(message,innerExcepsion)
        {
        }

    }

}
