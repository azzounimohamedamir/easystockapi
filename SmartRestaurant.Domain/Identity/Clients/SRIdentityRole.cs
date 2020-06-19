using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.Clients.Identity
{
    public class SRIdentityRole : IdentityRole
    {

        public string roleName { get; set; }
        public SRIdentityRole(string roleName) : base(roleName)
        {
            this.roleName = roleName;
        }
    }
}
