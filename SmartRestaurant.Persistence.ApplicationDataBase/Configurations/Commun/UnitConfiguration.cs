using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name).HasMaxLength(256).IsRequired();
            b.HasIndex(x => x.Name).HasName("UnitNameIndex").IsUnique(true);
            b.Property(x => x.Symbol).HasMaxLength(50).IsRequired();
            b.HasIndex(x => x.Symbol).IsUnique(true);
            b.ToTable("Units");
        }
    }
}
