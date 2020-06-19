using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Domain.BaseIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Identity.Guests
{
    public class GuestIdentityUser : BaseIdentityUser
    {
        public string RestuarantId { get; set; }
    }
}
