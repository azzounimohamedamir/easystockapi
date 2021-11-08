using System;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

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
        public bool OffersTakeout { get; set; }
        public string Tags { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public FoodBusinessState FoodBusinessState { get; set; }
        public FoodBusinessCategory FoodBusinessCategory { get; set; }
        public int FourDigitCode { get; set; }
        public Currencies DefaultCurrency { get; set; }
        public DateTime OrderNumberLastResetDateTime { get; set; }
    }
}