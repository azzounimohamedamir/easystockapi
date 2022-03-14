using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class LinkedDeviceDto
    {
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}