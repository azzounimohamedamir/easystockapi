using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Dishes;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes
{
    internal class DishIngredientConfiguration : IEntityTypeConfiguration<DishIngredient>
    {
        public void Configure(EntityTypeBuilder<DishIngredient> b)
        {
            b.HasKey(c => c.Id);
            b.Property(c => c.Id).ValueGeneratedNever();

            b.Property(c => c.DishId).IsRequired();
            b.Property(c => c.FoodId).IsRequired();

            b.HasOne(c => c.Dish)
                .WithMany(d => d.Ingredients)
                .HasForeignKey(i => i.DishId);

            b.HasOne(c => c.Food)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(i => i.FoodId);

            b.OwnsOne(c => c.Quantity);

            b.ToTable("DishIngredients");
        }
    }
}
