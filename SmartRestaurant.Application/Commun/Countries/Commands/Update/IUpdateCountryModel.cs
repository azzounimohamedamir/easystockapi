using SmartRestaurant.Application.Commun.Countries.Commands.Create;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Update
{
    public interface IUpdateCountryModel : ICreateCountryModel
    {
        string Id { get; set; }
    }
}