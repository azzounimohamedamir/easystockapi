using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Domain.Services;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Foods
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id)
                .ValueGeneratedNever();

            b.Property(a => a.Alias)
                .HasMaxLength(5);


            b.OwnsOne<ServiceDateTime>("DateService", nut => {
                nut.HasForeignKey("ServiceId");
                nut.OwnsOne<Time>("EndTime");
                nut.OwnsOne<Time>("StartTime");
            });
        
            b.ToTable("Services");
        }
    }
}
