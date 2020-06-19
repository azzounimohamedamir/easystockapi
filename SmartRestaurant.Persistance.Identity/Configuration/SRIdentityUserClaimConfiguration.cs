using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Clients.Identity;

namespace SmartRestaurant.Persistance.Identity.Configuration
{
    class SRIdentityUserClaimConfiguration : IEntityTypeConfiguration<SRIdentityUserClaim>
    {
        public void Configure(EntityTypeBuilder<SRIdentityUserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("SRUserClaims");
        }
    }
}
