using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes
{
    internal class DishFamilyConfiguration : IEntityTypeConfiguration<DishFamily>
    {
        public void Configure(EntityTypeBuilder<DishFamily> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);            
            b.Property(x => x.RestaurantId).IsRequired();
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name).HasMaxLength(256).IsRequired();            

            b.Property(x => x.SlugUrl).IsRequired();

            b.HasMany(c => c.Childs)
                .WithOne(ch => ch.Parent)
                .HasForeignKey(ch => ch.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(d => d.Restaurant)
                .WithMany(r => r.DishFamilies)
                .HasForeignKey(d => d.RestaurantId);

            b.HasOne(c => c.Picture).WithOne();

            b.ToTable("DishFamillies");
        }
    }
}
