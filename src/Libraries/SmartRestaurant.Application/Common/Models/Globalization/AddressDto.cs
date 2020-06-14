using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Models.Globalization
{
    public class AddressDto
    {
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public GeoPosition GeoPosition { get; set; }
    }
}
