using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Place : BaseEntity<Guid>
    {
        public Guid TableId { get; set; }
        public int PlaceNumber { get; set; }
        public Table Table { get; set; }
    }
}
