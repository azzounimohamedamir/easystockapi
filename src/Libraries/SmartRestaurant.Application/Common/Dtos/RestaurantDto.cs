using SmartRestaurant.Application.Common.Models.Globalization;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class RestaurantDto
    {
        public Guid RestaurantId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFreindly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
    }
}
