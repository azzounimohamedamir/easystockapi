using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Exceptions
{
    public class NotValidException:Exception
    {
        public readonly IList<ValidationFailure> Errors;

        public NotValidException() : base()
        {

        }
        public NotValidException(string message, Exception ex) : base(message, ex)
        {

        }

        public NotValidException(IList<ValidationFailure> errors)
        {
            Errors = errors;
        }
    }
}
