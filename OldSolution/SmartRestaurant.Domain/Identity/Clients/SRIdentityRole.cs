using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Domain.BaseIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Clients.Identity
{
    public class SRIdentityRole : IdentityRole
    {

        public string roleName { get; set; }
        public SRIdentityRole(string roleName):base(roleName)
        {
            this.roleName = roleName;
        }
    }
}
