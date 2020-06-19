using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(a => a.Name).HasMaxLength(256).IsRequired();

            b.HasMany(r => r.Areas)
                .WithOne(a => a.Floor)
                .HasForeignKey(a => a.FloorId)
                .OnDelete(DeleteBehavior.Restrict);

            b.ToTable("Floors");
        }
    }
}
