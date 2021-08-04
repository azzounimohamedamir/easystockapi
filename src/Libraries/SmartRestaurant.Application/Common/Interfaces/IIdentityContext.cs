using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IIdentityContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
    }
}