using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.BaseIdentity;
using SmartRestaurant.Domain.Clients.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity.TeamConfiguration
{
    public class BaseIdentityRoleClaimConfiguration : IEntityTypeConfiguration<BaseIdentityRoleClaim>
    {
        public void Configure(EntityTypeBuilder<BaseIdentityRoleClaim> builder)
        {
            // Primary key
            builder.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            builder.ToTable("BaseRoleClaims");
        }
    }
}
