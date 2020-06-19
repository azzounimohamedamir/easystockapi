using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class NotificationUserConfiguration : IEntityTypeConfiguration<NotificationUser>
    {
        public void Configure(EntityTypeBuilder<NotificationUser> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => new { x.NotificationId, x.UserId });

            b.ToTable("NotificationUsers");
        }
    }
}
