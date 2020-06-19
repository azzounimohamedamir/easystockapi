using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantFeatureConfiguration : IEntityTypeConfiguration<RestaurantFeature>
    {
        public void Configure(EntityTypeBuilder<RestaurantFeature> b)
        {
            b.HasKey(x => new { x.RestaurantId, x.FeatureId });
            b.HasOne(x => x.Restaurant)
                .WithMany(r => r.RestaurantFeatures)
                .HasForeignKey(x => x.RestaurantId);

            b.HasOne(x => x.Feature)
                .WithMany(e => e.RestaurantFeatures)
                .HasForeignKey(e => e.RestaurantId);

            b.ToTable("RestaurantFeatures");
        }
    }
}
