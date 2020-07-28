using System;
using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public Guid? FoodBusinessId { get; set; }
    }
}
