using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Cities.Commands;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Cities
{
    public class CityViewModel
    {
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public SelectList States { get; set; }
        public SelectList Countries { get; set; }
        public CreateCityModel CreateModel { get; set; }
        public UpdateCityModel UpdateModel { get; set; }

    }
}
