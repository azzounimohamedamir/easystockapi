using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class City :  AuditableEntity
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public GeoPosition GeoPosition { get; set; }
    }
}