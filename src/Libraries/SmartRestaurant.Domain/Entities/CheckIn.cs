using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class CheckIn
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public string Email  { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActivate { get; set; }
        public Guid hotelId { get; set; }
        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int LengthOfStay { get; set; }
        public DateTime Startdate { get; set; }

    }
}
