using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ZoneDto
    {
        public Guid ZoneId { get; set; }
        public string ZoneTitle { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}