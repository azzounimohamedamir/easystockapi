using System;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public BaseException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}