using SmartRestaurant.Application.Commun.Currencies.Commands.Create;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Currencies
{
    public class CurrencyViewModel
    {

        public CreateCurrencyModel CreateModel { get; set; }
        public UpdateCurrencyModel UpdateModel { get; set; }

    }
}
