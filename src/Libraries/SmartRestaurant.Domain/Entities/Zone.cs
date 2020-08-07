using SmartRestaurant.Domain.Common;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Zone : AuditableEntity
    {
        public Guid ZoneId { get; set; }
        public string ZoneTitle { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}
