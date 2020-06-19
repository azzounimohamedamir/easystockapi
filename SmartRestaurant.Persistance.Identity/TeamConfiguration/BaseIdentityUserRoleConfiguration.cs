using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.BaseIdentity;

namespace SmartRestaurant.Persistance.Identity.TeamConfiguration
{
    public class BaseIdentityUserRoleConfiguration : IEntityTypeConfiguration<BaseIdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<BaseIdentityUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("BaseUserRoles");
        }
    }
}
