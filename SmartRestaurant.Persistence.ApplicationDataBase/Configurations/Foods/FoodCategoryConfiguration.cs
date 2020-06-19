using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Foods;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Foods
{
    internal class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name).HasMaxLength(256).IsRequired();
            b.HasIndex(x => x.Name).HasName("FoodCategoryNameIndex").IsUnique(true);

            b.Property(x => x.SlugUrl).IsRequired();

            b.HasMany(c => c.Childs)
                .WithOne(ch => ch.Parent)
                .HasForeignKey(ch => ch.ParentId);

            b.HasOne(c => c.Picture).WithOne();

        }
    }
}
