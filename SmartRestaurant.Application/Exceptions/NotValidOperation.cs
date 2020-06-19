using System;

namespace SmartRestaurant.Application.Exceptions
{
    public class NotValidOperation : Exception
    {
        public NotValidOperation(string message) : base(message)
        {
        }
        public NotValidOperation(string message, Exception innerExcepsion)
            : base(message, innerExcepsion)
        {

        }
    }
}
