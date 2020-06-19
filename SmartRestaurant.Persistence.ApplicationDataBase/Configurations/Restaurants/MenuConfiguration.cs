using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(a => a.Name).HasMaxLength(256).IsRequired();

            b.HasOne(m => m.Restaurant)
                .WithMany(r => r.Menus)
                .HasForeignKey(m => m.RestaurantId);

            b.HasOne(m => m.Staff)
                 .WithMany(r => r.Menus)
                 .HasForeignKey(m => m.StaffId);

            b.HasMany(m => m.Items)
                .WithOne(it => it.Menu)
                .HasForeignKey(it => it.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            b.ToTable("Menus");
        }
    }
}
