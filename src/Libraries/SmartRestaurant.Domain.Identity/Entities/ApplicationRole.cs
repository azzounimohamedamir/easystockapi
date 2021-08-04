using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SmartRestaurant.Domain.Identity.Entities
{
    public class ApplicationRole : IdentityRole<string>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}