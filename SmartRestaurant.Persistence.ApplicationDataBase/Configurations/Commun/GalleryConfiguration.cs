using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);

            b.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            b.Property(x => x.SlugUrl)
               .HasMaxLength(256)
               .IsRequired();

            b.Property(x => x.SlugUrl).IsRequired();

            b.HasOne(x => x.Dish).WithOne(d => d.Gallery).HasForeignKey<Dish>(d => d.GalleryId);
            b.HasOne(x => x.MenuItem).WithOne(d => d.Gallery).HasForeignKey<MenuItem>(d => d.GalleryId);
            b.ToTable("Galleries");
        }
    }
}
