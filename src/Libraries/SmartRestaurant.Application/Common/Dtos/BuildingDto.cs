using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class BuildingDto
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public Guid HotelId { get; set; }
    }
}
