using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
            Errors = new List<string>();
        }

        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
    }
}