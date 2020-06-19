using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantKitchenConfiguration : IEntityTypeConfiguration<RestaurantKitchen>
    {
        public void Configure(EntityTypeBuilder<RestaurantKitchen> b)
        {
            b.HasKey(x => new { x.RestaurantId, x.KitchenId });
            b.HasOne(x => x.Restaurant)
                .WithMany(r => r.RestaurantKitchens)
                .HasForeignKey(x => x.RestaurantId);

            b.HasOne(x => x.Kitchen)
                .WithMany(e => e.RestaurantKitchens)
                .HasForeignKey(e => e.RestaurantId);

            b.ToTable("RestaurantKitchens");
        }
    }
}
