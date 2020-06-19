using System;

namespace SmartRestaurant.Application.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException()
        {

        }
        public DeleteFailureException(string message) : base(message)
        {

        }

    }
}
