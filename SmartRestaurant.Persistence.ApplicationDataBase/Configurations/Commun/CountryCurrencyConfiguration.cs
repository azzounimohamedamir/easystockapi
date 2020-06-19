using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun
{
    internal class CountryCurrencyConfiguration : IEntityTypeConfiguration<CountryCurrency>
    {
        public void Configure(EntityTypeBuilder<CountryCurrency> b)
        {
            b.HasKey(x => new { x.CountryId, x.CurrencyId });
            b.ToTable("CountriesCurrencies");
        }
    }
}
