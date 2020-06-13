using System;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Section : BaseEntity<Guid>
    {
        public Guid RestaurantId { get; set; }
       
        public Restaurant Restaurant { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
        public string ImageUri { get; set; }
    }
}
