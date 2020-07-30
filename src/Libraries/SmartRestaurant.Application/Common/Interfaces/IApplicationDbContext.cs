using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.FoodBusiness> FoodBusinesses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}