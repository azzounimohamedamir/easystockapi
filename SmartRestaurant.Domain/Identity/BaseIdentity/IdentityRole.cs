using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.BaseIdentity
{
    public class BaseIdentityRole : IdentityRole
    {

        public string roleName { get; set; }

        public BaseIdentityRole(string roleName) :base(roleName)
        {

        }
    }
}
