using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Identity.Guests;

namespace SmartRestaurant.Persistance.Identity.GuestConfiguration
{
    public class GuestIdentityRoleConfiguration : IEntityTypeConfiguration<GuestIdentityRole>
    {
        public void Configure(EntityTypeBuilder<GuestIdentityRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("GuestRoles");
        }
    }
}
