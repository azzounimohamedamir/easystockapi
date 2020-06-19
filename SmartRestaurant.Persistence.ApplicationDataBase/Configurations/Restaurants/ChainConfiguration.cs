using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Foods
{
    internal class ChainConfiguration : IEntityTypeConfiguration<Chain>
    {
        public void Configure(EntityTypeBuilder<Chain> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id)
                .ValueGeneratedNever();

            b.Property(a => a.Alias)
                .HasMaxLength(5);

            b.Property(a => a.Name)
                .HasMaxLength(256)
                .IsRequired();

            b.Property(a => a.SlugUrl).IsRequired();

            b.HasMany(a => a.Restaurants)
                .WithOne(r => r.Chain)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(c => c.Owner)
                .WithMany(o => o.Chains)
                .OnDelete(DeleteBehavior.Restrict);

            b.ToTable("Chains");
        }
    }
}
