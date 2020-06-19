using SmartRestaurant.Application.Commun.Countries.Commands.Create;

namespace SmartRestaurant.Application.Commun.State.Commands.Create
{
    public class UpdateStateModel : CreateStateModel, IUpdateStateModel
    {

        public string Id { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }

    }
}