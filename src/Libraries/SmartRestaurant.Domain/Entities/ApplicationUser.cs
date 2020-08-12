using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.Entities
{
    public sealed class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string fullName, string email, string userName)
        {
            FullName = fullName;
            UserName = userName;
            Email = email;
        }
        public ApplicationUser()
        {
            IsActive = true;
        }

        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
