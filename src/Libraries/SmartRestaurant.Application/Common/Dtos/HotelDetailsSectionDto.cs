using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class HotelDetailsSectionDto
    {
        public Guid HotelDetailsSectionId { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string HotelId { get; set; }
    }
}
