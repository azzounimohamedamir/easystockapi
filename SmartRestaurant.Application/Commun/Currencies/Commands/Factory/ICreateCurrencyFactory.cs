using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Factory
{
    public interface ICreateCurrencyFactory
    {
        Currency Create(string Name, string IsoCode, string Alias, bool IsDisabled);
    }

    public class CreateCurrencyFactory : ICreateCurrencyFactory
    {
        public Currency Create(string Name, string IsoCode, string Alias, bool IsDisabled)
        {
            var entity = new Currency();
            entity.Name = Name;
            entity.IsoCode = IsoCode;
            entity.Alias = Alias;
            entity.IsDisabled = IsDisabled;
            return entity;
        }
    }
}
