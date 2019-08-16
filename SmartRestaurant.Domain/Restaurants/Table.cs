using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Table : BaseEntity<Guid>
    {
        public Guid AreaId { get; set; }
        public int TableNumber { get; set; }
        public int Chair { get; set; }
        public int MaxChairCapacity { get; set; }
        public Area Area { get; set; }
    }
}