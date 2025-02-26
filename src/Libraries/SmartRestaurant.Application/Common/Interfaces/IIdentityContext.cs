using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IIdentityContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<LicenceKeys> LicenceKeys { get; set; }
        public DbSet<MyClients> MyClients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}