using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.BaseIdentity
{
    public class BaseIdentityUser : IdentityUser
    {       
        public String FirstName { get; set; }                
        public String LastName { get; set; }
    }
}
