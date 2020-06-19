using SmartRestaurant.Application.Commun.Address;
using System;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll
{
    public class RestaurantItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SlugUrl { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string IsDisabled { get; set; }

        public string ChainName { get; set; }
        public string RestaurantTypeName { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressModel AddressModel { get; set; }
    }
}