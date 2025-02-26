using SmartRestaurant.Domain.Common;
using System;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    public class City : AuditableEntity
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}