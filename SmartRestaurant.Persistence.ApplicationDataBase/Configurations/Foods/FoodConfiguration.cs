using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Foods
{
    internal class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);//NewGuid()
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias)
                .HasMaxLength(5);
            b.Property(a => a.Name)
                .HasMaxLength(256)
                .IsRequired();
            b.HasIndex(a => a.Name)
                .HasName("FoodNameIndex").IsUnique(true);

            //Not visible in UI Interface
            b.Property(a => a.SlugUrl).IsRequired();

            b.Property(a => a.FoodCategoryId).IsRequired();
            b.Property(a => a.UnitId).IsRequired();
            
            b.HasMany(a => a.Compositions)
                .WithOne(c => c.Food)
                .HasForeignKey(c => c.FoodId)
                .OnDelete(DeleteBehavior.Cascade);

            //EF  Core
            //Food_Quantity_UnitId
            //Food_Quantity_Value

            b.OwnsOne<Nutrition>("Nutrition", nut => {
                nut.HasForeignKey("FoodId");
                nut.OwnsOne<Quantity>("Quantity", Qt => 
                {
                    Qt.HasOne(u=>u.Unit).WithMany();
                });                
            });

            b.HasOne(a => a.Picture).WithOne();
            b.HasMany(f => f.DishIngredients)
                .WithOne(di => di.Food)
                .HasForeignKey(di => di.FoodId);

            b.ToTable("Foods");
        }
    }
}
