using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

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