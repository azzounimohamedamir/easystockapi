using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes
{
    internal class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(d => d.Id);//NewGuid()
            b.Property(d => d.Id).ValueGeneratedNever();
            b.Property(d => d.Alias)
                .HasMaxLength(5);
            b.Property(d => d.Name)
                .HasMaxLength(256)
                .IsRequired();

            //Not visible in UI Interface
            b.Property(d => d.SlugUrl).IsRequired();

            b.Property(d => d.FamillyId).IsRequired();
            b.Property(d => d.RestaurantId).IsRequired();

            b.OwnsOne(d => d.PreparationTime);
            b.OwnsOne(d => d.ServiceTime);

            b.HasOne(d => d.Restaurant)
                .WithMany(r => r.Dishes)
                .HasForeignKey(d => d.RestaurantId);

            b.HasOne(d => d.Family)
                .WithMany(f => f.Dishes)
                .HasForeignKey(d => d.FamillyId);

            b.HasMany(d => d.Ingredients)
                .WithOne(c => c.Dish)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(d => d.Gallery)
                .WithOne(g => g.Dish)
                .HasForeignKey<Gallery>(gal => gal.DishId);

            b.HasMany(d => d.ChildAccompaniments)
                .WithOne(dacc => dacc.Parent)
                .HasForeignKey(dacc => dacc.ParentId);

            b.HasMany(d => d.ParentAccompaniments)
                .WithOne(dacc => dacc.Accompanying)
                .HasForeignKey(dacc => dacc.AccompanyingId);

            b.ToTable("Dishes");

        }
    }
}
