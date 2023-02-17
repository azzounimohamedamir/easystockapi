using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class FoodBusiness : Entreprise
    {
        public Guid FoodBusinessId { get; set; }
        public double AverageRating { get; set; }
        public int NumberRatings { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFriendly { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public bool AcceptDelivery { get; set; }
        public bool OffersTakeout { get; set; }
        public string Tags { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public FoodBusinessState FoodBusinessState { get; set; }
        public FoodBusinessCategory FoodBusinessCategory { get; set; }
        public int FourDigitCode { get; set; }
        public Currencies DefaultCurrency { get; set; }
        public DateTime OrderNumberLastResetDateTime { get; set; }
        public CommissionConfigs CommissionConfigs { get; set; }
        public bool IsActivityFrozen { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string NearbyLocationDescription { get; set; }
        public decimal NearbyLocationPrice { get; set; }
        public string FarLocationDescription { get; set; }
        public decimal FarLocationPrice { get; set; }
         public bool isMenuItemDetailed { get; set; }

    }
}