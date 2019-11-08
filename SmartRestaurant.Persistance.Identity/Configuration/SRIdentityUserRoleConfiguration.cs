using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Clients.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity.Configuration
{
    public class SRIdentityUserRoleConfiguration : IEntityTypeConfiguration<SRIdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<SRIdentityUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("SRUserRoles");
        }
    }
}
