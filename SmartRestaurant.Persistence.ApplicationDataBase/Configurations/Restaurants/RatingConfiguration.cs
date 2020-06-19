using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RatingConfiguration : IEntityTypeConfiguration<RestaurantRating>
    {
        public void Configure(EntityTypeBuilder<RestaurantRating> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);

            b.ToTable("RestaurantRatings");
        }
    }
}
