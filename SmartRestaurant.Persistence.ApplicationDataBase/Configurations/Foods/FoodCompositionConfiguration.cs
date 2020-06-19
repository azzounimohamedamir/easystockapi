using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Foods
{
    internal class FoodCompositionConfiguration : IEntityTypeConfiguration<FoodComposition>
    {
        public void Configure(EntityTypeBuilder<FoodComposition> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);//NewGuid()
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias)
                .HasMaxLength(5);

            b.Property(a => a.FoodId).IsRequired();
            
            //EF  Core
            //Food_Quantity_UnitId
            //Food_Quantity_Value

            b.OwnsOne<Quantity>("Quantity", Qt => {
                Qt.HasOne(u => u.Unit).WithMany();                
            });            

            b.ToTable("FoodCompositions");
        }
    }
}
