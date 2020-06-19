using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.Currencies.Queries;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Countries
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {

        }
        public CreateCountryModel CreateModel { get; set; }
        public UpdateCountryModel UpdateModel { get; set; }
        public List<CurrencyItemModel> CurrenciesItemModel { get; set; }


    }


}
