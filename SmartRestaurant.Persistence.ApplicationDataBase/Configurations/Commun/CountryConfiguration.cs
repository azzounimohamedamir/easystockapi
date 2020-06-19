using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
            b.HasIndex(x => x.Name)
                .HasName("CountryNameIndex")
                .IsUnique(true);
            b.Property(x => x.IsoCode)
                .HasMaxLength(5)
                .IsRequired();
            b.HasMany(x => x.States)
                .WithOne(s => s.Country)
                .HasForeignKey(s => s.CountryId);

            b.HasMany(x => x.Currencies)
                .WithOne(cc => cc.Country)
                .HasForeignKey(cc => cc.CountryId)
                .OnDelete(DeleteBehavior.Cascade);


            b.ToTable("Countries");
        }
    }
}
