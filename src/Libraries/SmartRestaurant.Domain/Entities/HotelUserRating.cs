using System;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.Entities
{
    public class HotelUserRating
    {
        public Guid HotelId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int Rating { get; set; }

    }
}