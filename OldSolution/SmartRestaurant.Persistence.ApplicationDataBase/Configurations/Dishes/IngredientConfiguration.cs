using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> b)
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

            b.HasOne(d => d.Restaurant)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(d => d.RestaurantId);

            b.HasOne(d => d.Unit)
                .WithMany()
                .HasForeignKey(d => d.UnitId);

            b.HasOne(c => c.Picture).WithOne();

            b.ToTable("Ingredients");
        }
    }
}
