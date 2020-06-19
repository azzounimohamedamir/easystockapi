using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantRecommendationConfiguration : IEntityTypeConfiguration<RestaurantRecommendation>
    {
        public void Configure(EntityTypeBuilder<RestaurantRecommendation> b)
        {
            b.HasKey(x => new { x.RestaurantId, x.RecommendationId });
            b.HasOne(x => x.Restaurant)
                .WithMany(r => r.RestaurantRecommendations)
                .HasForeignKey(x => x.RestaurantId);

            b.HasOne(x => x.Recommendation)
                .WithMany(e => e.RestaurantRecommendations)
                .HasForeignKey(e => e.RestaurantId);

            b.ToTable("RestaurantRecommendations");
        }
    }
}
