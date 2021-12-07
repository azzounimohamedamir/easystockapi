using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ZoneWithTablesDto
    {
        public Guid ZoneId { get; set; }
        public string ZoneTitle { get; set; }
        public Guid FoodBusinessId { get; set; }
        public List<TableDto> Tables { get; set; }
    }
}
