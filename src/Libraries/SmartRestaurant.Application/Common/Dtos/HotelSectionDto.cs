using Org.BouncyCastle.Utilities;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class HotelSectionDto
    {
        public Guid HotelSectionId { get; set; }
        public string Picture { get; set; }
        public Names Names { get; set; }
    }
}
