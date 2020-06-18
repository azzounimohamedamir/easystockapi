using SmartRestaurant.Application.Common.Dtos.ValueObjects.Globalization;
using SmartRestaurant.Application.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class RestaurantDto
    {
        public Guid RestaurantId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFreindly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
        public RestaurantState RestaurantState { get; set; }
    }
}
