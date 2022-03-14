using System.Linq;
using FluentValidation.Results;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(ValidationResult result) : base(400, "Validation error")
        {
            Errors.AddRange(result.Errors.Select(error => error.ErrorMessage));
        }

        public ValidationException(string message) : base(400, "Validation error")
        {
            Errors.Add(message);
        }
    }
}