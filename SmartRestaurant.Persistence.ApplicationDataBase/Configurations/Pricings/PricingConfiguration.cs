using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Pricings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Pricings
{

    internal class PricingConfiguration : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(a => a.Name).HasMaxLength(256);

           
            b.HasOne(r => r.Product)
             .WithOne(a => a.Pricing)
             .HasForeignKey<Pricing>(x => x.ProductId);

            b.HasOne(r => r.Dish)
            .WithOne(a => a.Pricing)
            .HasForeignKey<Pricing>(x => x.DishId);

            b.OwnsOne<Price>(nameof(Pricing.Gain), x =>
             {
                 x.HasForeignKey("SalePricingId");
                 x.HasOne(i => i.Currency).WithMany()
                 .OnDelete(DeleteBehavior.Restrict);
             });
            b.OwnsOne<Price>(nameof(Pricing.PurchasePriceHT), x =>
            {
                x.HasForeignKey("PurchasePricingId");
                x.HasOne(i => i.Currency).WithMany()              
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
