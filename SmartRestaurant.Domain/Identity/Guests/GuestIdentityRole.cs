using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.Identity.Guests
{
    public class GuestIdentityRole : IdentityRole
    {
        public string roleName { get; set; }
        public GuestIdentityRole(string roleName) : base(roleName)
        {

        }
    }
}
