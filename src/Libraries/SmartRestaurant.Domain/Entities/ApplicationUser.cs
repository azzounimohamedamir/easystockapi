using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            IsActive = true;
        }

        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
