using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class Speciality : BaseEntity<Guid>
    {
        public ICollection<RestaurantSpecialty> RestaurantSpecialties { get; set; }
    }
}
