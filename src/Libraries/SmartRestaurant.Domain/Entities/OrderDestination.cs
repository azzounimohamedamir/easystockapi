using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderDestination
    {
        public Guid OrderDestinationId { get; set; }
        public Guid HotelId { get; set; }
        public Names Names { get; set; }
    }
}
