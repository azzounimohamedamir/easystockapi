using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class GeoPosition
    {
        public string Latitude { get; protected set; }
        public string Longitude { get; protected set; }
    }
}
