using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Cities.Queries;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Cities
{
    public class CityItemViewModel
    {

        public CityFilterViewModel CityFilterViewModel { get; set; }

        public IEnumerable<CityItemModel> Cities { get; set; }


    }

    public class CityFilterViewModel
    {
        public SelectList Countries { get; set; }
        public SelectList States { get; set; }
        public string SelectedCountryId { get; set; }
        public string SelectedStateId { get; set; }
    }

}
