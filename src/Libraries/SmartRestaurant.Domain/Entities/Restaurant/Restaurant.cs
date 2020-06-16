using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Restaurant : AuditableEntity
    {
        public Guid RestaurantId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public Address Address { get; set; }
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
