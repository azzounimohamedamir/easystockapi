using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IIdentityContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}