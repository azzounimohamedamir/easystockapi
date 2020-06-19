using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.BaseIdentity;

namespace SmartRestaurant.Persistance.Identity.TeamConfiguration
{
    class BaseIdentityUserClaimConfiguration : IEntityTypeConfiguration<BaseIdentityUserClaim>
    {
        public void Configure(EntityTypeBuilder<BaseIdentityUserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("BaseUserClaims");
        }
    }
}
