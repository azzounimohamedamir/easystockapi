using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class HotelSection
    {
        public Guid HotelSectionId { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public byte[] Picture { get; set; }
        public Names Names { get; set; }
    }
}
