using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.BaseIdentity
{
    public class BaseIdentityRole : IdentityRole
    {

        public string roleName { get; set; }

        public BaseIdentityRole(string roleName) : base(roleName)
        {

        }
    }
}
