using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> b)
        {
            //inherit BaseEntity<TId> 
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedNever();
            b.Property(a => a.Alias).HasMaxLength(5);
            b.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            b.HasMany(x => x.Cities)
                .WithOne(s => s.State)
                .HasForeignKey(s => s.StateId);

            b.ToTable("States");
        }
    }
}
