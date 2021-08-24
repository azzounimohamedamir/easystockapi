using System;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities
{
    public class LinkedDevice : AuditableEntity
    {
        public Guid LinkedDeviceId { get; set; }
        public string IdentifierDevice { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}