using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class HotelDetailsSection
    {
        public Guid HotelDetailsSectionId { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
    }
}
