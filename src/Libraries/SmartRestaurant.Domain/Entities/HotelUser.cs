using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class HotelUser
    {
        public string ApplicationUserId { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel{ get; set; }
    }
}
