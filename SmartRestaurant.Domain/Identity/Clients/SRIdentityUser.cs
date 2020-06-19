using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Domain.BaseIdentity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SmartRestaurant.Domain.Clients.Identity
{
    public class SRIdentityUser: BaseIdentityUser
    {
        public string RestaurantId { get; set; }
        public string ChainId { get; set; }
        public bool IsDisabled { get; set; }
    }
}
