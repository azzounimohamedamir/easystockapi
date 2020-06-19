using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Identity.Guests;

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
