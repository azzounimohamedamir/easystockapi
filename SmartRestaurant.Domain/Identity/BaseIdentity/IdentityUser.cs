using Microsoft.AspNetCore.Identity;
using System;

namespace SmartRestaurant.Domain.BaseIdentity
{
    public class BaseIdentityUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
