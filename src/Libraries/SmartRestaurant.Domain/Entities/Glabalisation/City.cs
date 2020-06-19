using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class City :  AuditableEntity
    {
        public Guid CityId { get; protected set; }
        public string Name { get; protected set; }
        public GeoPosition GeoPosition { get; protected set; }
    }
}