using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class Zone : AuditableEntity
    {
        public Zone()
        {
            Tables = new List<Table>();
        }
        public Guid ZoneId { get; set; }
        public string ZoneTitle { get; set; }
        public Names Names { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
        public virtual IList<Table> Tables { get; set; }
    }
}