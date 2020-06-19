using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantMealConfiguration : IEntityTypeConfiguration<RestaurantMeal>
    {
        public void Configure(EntityTypeBuilder<RestaurantMeal> b)
        {
            b.HasKey(x => new { x.RestaurantId, x.MealId });
            b.HasOne(x => x.Restaurant)
                .WithMany(r => r.RestaurantMeals)
                .HasForeignKey(x => x.RestaurantId);

            b.HasOne(x => x.Meal)
                .WithMany(e => e.RestaurantMeals)
                .HasForeignKey(e => e.RestaurantId);

            b.ToTable("RestaurantMeals");
        }
    }
}
