using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class AccountCreationException : BaseException
    {
        public AccountCreationException(IEnumerable<IdentityError> result) : base(409, "Account creation failed")
        {
            Errors.AddRange(result.Select(error => error.Description));
        }
    }
}