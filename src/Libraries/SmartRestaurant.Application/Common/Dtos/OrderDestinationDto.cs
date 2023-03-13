using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class OrderDestinationDto
    {
        public Guid OrderDestinationId { get; set; }

        public Guid HotelId { get; set; } 
        public Names Names { get; set; }
    }
}
