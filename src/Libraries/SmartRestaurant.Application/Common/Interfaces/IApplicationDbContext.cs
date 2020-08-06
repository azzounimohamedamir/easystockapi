using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.FoodBusiness> FoodBusinesses { get; set; }
        public DbSet<FoodBusinessImage> FoodBusinessImages { get; set; }
        public DbSet<FoodBusinessUser> FoodBusinessUsers { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Table> Tables { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}