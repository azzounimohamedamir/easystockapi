using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Area : BaseEntity<Guid>
    {
        public Guid FloorId { get; set; }
        public virtual Floor Floor { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}