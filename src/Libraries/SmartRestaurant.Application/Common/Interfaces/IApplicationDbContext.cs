using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}