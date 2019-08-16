using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class MailingConfiguration : IEntityTypeConfiguration<Mailing>
    {
        public void Configure(EntityTypeBuilder<Mailing> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();


            b.HasMany(x => x.Users)
                .WithOne(cc => cc.Mailing)
                .HasForeignKey(cc => cc.MailingId)
                .OnDelete(DeleteBehavior.Cascade);


            b.ToTable("Mailings");
        }
    }
}
