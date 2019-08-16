using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes
{
    public class DishEquivalenceConfiguration : IEntityTypeConfiguration<DishEquivalence>
    {
        public void Configure(EntityTypeBuilder<DishEquivalence> b)
        {

            b.HasKey(d => new { d.ParentId, d.EquivalenceId });

            b.HasOne(d => d.Parent)
                .WithMany(r => r.ParentEquivalences)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(d => d.Equivalence)
                .WithMany(r => r.ChildEquivalences)
                .HasForeignKey(d => d.EquivalenceId);
                

            b.OwnsOne<Quantity>("QuantityParent", Qt => 
            {
                Qt.HasOne(u => u.Unit).WithMany();
            });

            b.OwnsOne<Quantity>("QuantityEquivalence", Qt =>
            {
                Qt.HasOne(u => u.Unit).WithMany();
            });

            b.ToTable("DishEquivalences");
        }
    }
}
