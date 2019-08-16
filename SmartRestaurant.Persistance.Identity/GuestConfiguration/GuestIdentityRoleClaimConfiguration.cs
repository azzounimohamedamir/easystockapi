using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.BaseIdentity;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Identity.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity.GuestConfiguration
{
    public class GuestIdentityRoleClaimConfiguration : IEntityTypeConfiguration<GuestIdentityRoleClaim>
    {
        public void Configure(EntityTypeBuilder<GuestIdentityRoleClaim> builder)
        {
            // Primary key
            builder.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            builder.ToTable("GuestRoleClaims");
        }
    }
}
