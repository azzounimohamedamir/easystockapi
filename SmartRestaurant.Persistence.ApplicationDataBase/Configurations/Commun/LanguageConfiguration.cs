using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
            b.HasIndex(x => x.Name)
                .HasName("LanguageNameIndex")
                .IsUnique(true);
            b.Property(x => x.IsoCode)
                .HasMaxLength(5)
                .IsRequired();
            b.Property(x => x.IsRTL).HasDefaultValueSql("0");
            b.ToTable("Languages");

        }
    }
}
