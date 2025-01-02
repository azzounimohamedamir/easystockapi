using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    public class City : AuditableEntity
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}