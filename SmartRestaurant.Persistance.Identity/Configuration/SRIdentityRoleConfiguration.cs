using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Clients.Identity;

namespace SmartRestaurant.Persistance.Identity.Configuration
{
    public class SRIdentityRoleConfiguration : IEntityTypeConfiguration<SRIdentityRole>
    {
        public void Configure(EntityTypeBuilder<SRIdentityRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("SRRoles");
        }
    }
}
