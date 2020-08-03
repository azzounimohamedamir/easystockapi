using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodBusinessUser>()
                .HasKey(o => new { o.ApplicationUserId, o.FoodBusinessId });
        }

        public DbSet<FoodBusiness> FoodBusinesses { get; set; }
        public DbSet<FoodBusinessImage> FoodBusinessImages { get; set; }
        public DbSet<FoodBusinessUser> FoodBusinessUsers { get; set; }
    }
}