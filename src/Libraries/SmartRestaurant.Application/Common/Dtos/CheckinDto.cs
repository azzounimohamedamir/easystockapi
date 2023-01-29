using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CheckinDto
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActivate { get; set; }
        public Guid hotelId { get; set; }
        public string hotelName { get; set; }
        public string buildingName { get; set; }

        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int LengthOfStay { get; set; }
        public DateTime Startdate { get; set; }
    }
}
