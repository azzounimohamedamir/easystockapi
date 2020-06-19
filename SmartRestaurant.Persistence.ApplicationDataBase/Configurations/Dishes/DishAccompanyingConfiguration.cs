using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes
{
    public class DishAccompanyingConfiguration : IEntityTypeConfiguration<DishAccompanying>
    {
        public void Configure(EntityTypeBuilder<DishAccompanying> b)
        {
            b.HasKey(d => new { d.ParentId, d.AccompanyingId });

            b.HasOne(d => d.Parent)
                .WithMany(r => r.ChildAccompaniments)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(d => d.Accompanying)
                .WithMany(r => r.ParentAccompaniments)
                .HasForeignKey(d => d.AccompanyingId);


            b.OwnsOne<Quantity>("Quantity", Qt =>
            {
                Qt.HasOne(u => u.Unit).WithMany();
            });
        }
    }
}
