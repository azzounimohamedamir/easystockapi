using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class DeviceID : AuditableEntity
    {
        public Guid DeviceIDId { get; set; }
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}
