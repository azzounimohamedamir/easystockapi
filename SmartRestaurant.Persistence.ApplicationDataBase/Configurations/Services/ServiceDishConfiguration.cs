using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Services
{
    public class ServiceDishConfiguration : IEntityTypeConfiguration<ServiceDish>
    {
        public void Configure(EntityTypeBuilder<ServiceDish> b)
        {
            b.HasKey(a => a.Id);
            b.Property(a => a.Id)
                .ValueGeneratedNever();

            b.Property(a => a.Alias)
                .HasMaxLength(15);

            b.HasOne(a => a.Service)
                .WithMany(s => s.ServiceDishes)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            b.OwnsOne<Quantity>("Quantity", Qt => {
                Qt.HasOne(x => x.Unit)
                .WithMany()
                .HasForeignKey("UnitId");               
            });

            b.ToTable("ServiceDishes");
        }
    }
}
