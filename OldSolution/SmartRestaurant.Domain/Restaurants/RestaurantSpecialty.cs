using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class RestaurantSpecialty
    {
        public Guid RestaurantId { get; set; }
        public Guid SpecialtyId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Speciality Specialty { get; set; }
    }
}