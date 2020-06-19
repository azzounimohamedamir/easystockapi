using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Menu : BaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
        public Guid? StaffId { get; set; }

        public Restaurant Restaurant { get; set; }
        public ICollection<MenuItem> Items { get; set; }

        public Staff Staff { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
