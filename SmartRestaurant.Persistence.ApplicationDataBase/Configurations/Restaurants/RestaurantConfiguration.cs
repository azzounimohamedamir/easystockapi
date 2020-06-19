using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(a => a.Name).HasMaxLength(256).IsRequired();
            //b.HasIndex(a => a.Name).HasName("RestaurantNameIndex").IsUnique(true);
            b.Property(a => a.SlugUrl).IsRequired();

            b.OwnsOne<Address>("Address", a =>
            {
                a.HasForeignKey("RestaurantId");
            });

            b.OwnsOne<PriceRange>("PriceRange", pr =>
            {
                pr.HasOne(x => x.Currency).WithMany()
                .HasForeignKey("CurrencyId");
                pr.HasForeignKey("RestaurantId");
            });

            b.HasMany(r => r.Contacts)
                .WithOne(c => c.Restaurant)
                .HasForeignKey(c => c.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(r => r.Floors)
                .WithOne(f => f.Restaurant)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(r => r.Tarifications)
                .WithOne(f => f.Restaurant)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(r => r.Staffs)
                .WithOne(s => s.Restaurant)
                .HasForeignKey(s => s.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(r => r.RestaurantRatings)
                .WithOne(s => s.Restaurant)
                .HasForeignKey(s => s.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(r => r.DishFamilies)
                .WithOne(df => df.Restaurant)
                .HasForeignKey(df => df.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(r => r.ProductFamilies)
               .WithOne(pf => pf.Restaurant)
               .HasForeignKey(pf => pf.RestaurantId)
               .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(c => c.Owner)
                .WithMany(o => o.Restaurants);

            b.ToTable("Restaurants");
        }
    }
}
