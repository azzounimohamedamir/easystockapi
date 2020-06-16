using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    [Owned]
    public class Address
    {
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public GeoPosition GeoPosition { get; set; }
    }
}
