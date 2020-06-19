using SmartRestaurant.Application.Commun.Countries.Commands.Create;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Update
{
    public class UpdateCountryModel : CreateCountryModel, IUpdateCountryModel
    {
        public string Id { get; set; }

    }
}