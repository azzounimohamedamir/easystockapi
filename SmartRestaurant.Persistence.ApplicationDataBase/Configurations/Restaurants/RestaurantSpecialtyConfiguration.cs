using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantSpecialtyConfiguration : IEntityTypeConfiguration<RestaurantSpecialty>
    {
        public void Configure(EntityTypeBuilder<RestaurantSpecialty> b)
        {
            b.HasKey(x => new { x.RestaurantId, x.SpecialtyId });
            b.HasOne(x => x.Restaurant)
                .WithMany(r => r.RestaurantSpecialties)
                .HasForeignKey(x => x.RestaurantId);

            b.HasOne(x => x.Specialty)
                .WithMany(e => e.RestaurantSpecialties)
                .HasForeignKey(e => e.RestaurantId);

            b.ToTable("RestaurantSpecialties");
        }
    }
}
