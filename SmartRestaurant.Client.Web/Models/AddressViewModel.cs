using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Address;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models
{
    public class AddressViewModel   
    {
        private AddressViewModel() { }

        public AddressViewModel(IEnumerable<Country> countries
            ,string selectedCountry=null)
        {
            Countries = new SelectList(countries, "Name", "Name", selectedCountry);
            AddressModel = new AddressModel();
        }
        public AddressModel AddressModel { get; set; }
        public SelectList Countries { get; set; }
        public SelectList States { get; set; }
        public SelectList Cities { get; set; }
    }
}
