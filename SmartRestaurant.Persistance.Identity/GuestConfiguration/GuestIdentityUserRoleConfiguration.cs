using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Identity.Guests;

namespace SmartRestaurant.Persistance.Identity.GuestConfiguration
{
    public class GuestIdentityUserRoleConfiguration : IEntityTypeConfiguration<GuestIdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<GuestIdentityUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("GuestUserRoles");
        }
    }
}
