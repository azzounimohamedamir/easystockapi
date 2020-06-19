using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants
{
    internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(a => a.Id);
            b.Property(a => a.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(a => a.UserName).HasMaxLength(256);
            b.Property(a => a.FirstName).HasMaxLength(256).IsRequired();
            b.Property(a => a.LastName).HasMaxLength(256).IsRequired();

            b.OwnsOne<Address>("Address", a =>
            {
                a.HasForeignKey("StaffId");
            });
            //b.OwnsMany<Contact>("Contacts", c => {
            //    c.HasForeignKey("StaffId");
            //});

            b.HasMany(r => r.Contacts)
                .WithOne(s => s.Staff)
                .HasForeignKey(s => s.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            b.ToTable("Staffs");
        }
    }
}
