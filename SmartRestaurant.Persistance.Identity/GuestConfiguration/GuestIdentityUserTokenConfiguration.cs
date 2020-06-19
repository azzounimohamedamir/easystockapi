using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Identity.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity.GuestConfiguration
{
    public class GuestIdentityUserTokenConfiguration : IEntityTypeConfiguration<GuestIdentityUserToken>
    {
        public void Configure(EntityTypeBuilder<GuestIdentityUserToken> builder)
        {
            // Composite primary key consisting of the UserId, LoginProvider and Name
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.LoginProvider).HasMaxLength(128);
            builder.Property(t => t.Name).HasMaxLength(128);

            // Maps to the AspNetUserTokens table
            builder.ToTable("GuestUserTokens");
        }
    }
}
