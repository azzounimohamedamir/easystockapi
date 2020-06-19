using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class MailingUserConfiguration : IEntityTypeConfiguration<MailingUser>
    {
        public void Configure(EntityTypeBuilder<MailingUser> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => new { x.MailingId, x.UserId });


            b.ToTable("MailingUsers");
        }
    }
}
