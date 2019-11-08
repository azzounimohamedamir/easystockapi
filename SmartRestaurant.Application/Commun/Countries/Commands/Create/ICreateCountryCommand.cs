using SmartRestaurant.Application.Commun.Countries.Commands.Create;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Create
{
    public interface ICreateCountryCommand
    {
        void Execute(CreateCountryModel model);
    }
}