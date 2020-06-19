using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class RestaurantPriceTypeConfiguration : IEntityTypeConfiguration<RestaurantPriceType>
    {
        public void Configure(EntityTypeBuilder<RestaurantPriceType> b)
        {
            b.HasKey(x => new { x.RestaurantId, x.PriceTypeId });
            b.HasOne(x => x.Restaurant)
                .WithMany(r => r.RestaurantPriceTypes)
                .HasForeignKey(x => x.RestaurantId);

            b.HasOne(x => x.PriceType)
                .WithMany(e => e.RestaurantPriceTypes)
                .HasForeignKey(e => e.RestaurantId);

            b.ToTable("RestaurantPriceTypes");
        }
    }
}
