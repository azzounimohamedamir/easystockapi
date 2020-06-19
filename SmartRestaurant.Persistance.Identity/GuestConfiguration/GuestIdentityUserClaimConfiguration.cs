using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Identity.Guests;

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
