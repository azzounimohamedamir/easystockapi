using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities.User;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IIdentityDbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}