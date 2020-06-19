namespace SmartRestaurant.Application.Commun.Cities.Commands.Factory
{
    public interface ICreateCityFactory
    {
        Domain.Commun.City Create(string Name, string IsoCode,
            string StateId, string Alias, bool IsDisabled);


    }
    public class CreateCityFactory : ICreateCityFactory
    {
        public Domain.Commun.City Create(string Name, string IsoCode,
            string StateId, string Alias, bool IsDisabled)
        {
            var entity = new Domain.Commun.City();

            entity.Name = Name;
            entity.IsoCode = IsoCode;
            entity.StateId = StateId;
            entity.Alias = Alias;
            entity.IsDisabled = IsDisabled;
            return entity;


        }
    }
}
