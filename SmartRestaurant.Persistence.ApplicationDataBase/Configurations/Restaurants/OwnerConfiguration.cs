using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(o => o.Id);
            b.Property(o => o.Id).ValueGeneratedNever();
            b.Property(o => o.Alias).HasMaxLength(5);
            b.Property(o => o.UserName).HasMaxLength(256);
            b.Property(o => o.FirstName).HasMaxLength(256).IsRequired();
            b.Property(o => o.LastName).HasMaxLength(256).IsRequired();

            b.OwnsOne<Address>("Address", o => {
                o.HasForeignKey("OwnerId");                
            });            

            b.HasMany(o => o.Contacts)
                .WithOne(c => c.Owner)
                .HasForeignKey(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            b.ToTable("Owners");
        }
    }
}
