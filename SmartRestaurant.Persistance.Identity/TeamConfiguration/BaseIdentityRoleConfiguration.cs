using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.BaseIdentity;

namespace SmartRestaurant.Persistance.Identity.TeamConfiguration
{
    public class BaseIdentityRoleConfiguration : IEntityTypeConfiguration<BaseIdentityRole>
    {
        public void Configure(EntityTypeBuilder<BaseIdentityRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("BaseRoles");
        }
    }
}
