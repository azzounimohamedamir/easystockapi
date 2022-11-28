using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class HotelSectionDto
    {
        public Guid HotelSectionId { get; set; }
        public string Picture { get; set; }
        public Names Names { get; set; }
        public string HotelId { get; set; }
    }
}
