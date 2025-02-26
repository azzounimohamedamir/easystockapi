using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class UserManagerException : BaseException
    {
        public UserManagerException(IEnumerable<IdentityError> result) : base(422, "Errors related to user manager ")
        {
            Errors.AddRange(result.Select(error => error.Description));
        }
    }
}