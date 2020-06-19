using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            b.Property(x => x.ImageUrl)
                .HasMaxLength(2000)
                .IsRequired();
            b.Property(x => x.SlugUrl).IsRequired();

            b.ToTable("Pictures");
        }
    }
}
