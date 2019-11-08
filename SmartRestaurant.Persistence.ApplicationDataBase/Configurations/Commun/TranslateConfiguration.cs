using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class TranslateConfiguration : IEntityTypeConfiguration<Translate>
    {
        public void Configure(EntityTypeBuilder<Translate> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();            
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Text)
                .HasMaxLength(256);


            b.ToTable("Translates");
        }
    }
}
