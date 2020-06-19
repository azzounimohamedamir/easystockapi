using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Identity.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity.GuestConfiguration
{
    public class GuestIdentityUserClaimConfiguration : IEntityTypeConfiguration<GuestIdentityUserClaim>
    {
        public void Configure(EntityTypeBuilder<GuestIdentityUserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("GuestUserClaims");
        }
    }
}
