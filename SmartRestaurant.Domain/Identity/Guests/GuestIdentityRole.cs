using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Domain.BaseIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Identity.Guests
{
    public class GuestIdentityRole : IdentityRole
    {
        public string roleName { get; set; }
        public GuestIdentityRole(string roleName):base(roleName)
        {
                
        }
    }
}
