using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.FoodBusiness> FoodBusinesses { get; set; }
        public DbSet<FoodBusinessImage> FoodBusinessImages { get; set; }
        public DbSet<FoodBusinessUser> FoodBusinessUsers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}