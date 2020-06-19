using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(a => a.Name).HasMaxLength(256).IsRequired();

            b.HasOne(m => m.Menu)
                .WithMany(r => r.Items)
                .HasForeignKey(m => m.MenuId);


            b.HasMany(m => m.Dishes);
            b.HasMany(m => m.Products);

            b.HasOne(d => d.Gallery)
                .WithOne(g => g.MenuItem)
                .HasForeignKey<Gallery>(gal => gal.MenuItemId);

            b.OwnsOne<Price>("Discount", dis =>
            {
                dis.HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey("CurrencyId");
                dis.HasForeignKey("MenuItemId");
            });

            b.ToTable("MenuItems");
        }
    }
}
