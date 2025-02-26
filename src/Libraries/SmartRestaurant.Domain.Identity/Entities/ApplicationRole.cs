using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Identity.Entities
{
    public class ApplicationRole : IdentityRole<string>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}