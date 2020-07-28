using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using SmartRestaurant.Domain.Interfaces;

namespace SmartRestaurant.Domain.Entities
{
    public class FoodBusiness : AuditableEntity,IOrganization
    {
       
        public Guid FoodBusinessId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public string NameTurkish { get; set; }
        public string NameChinese { get; set; }
        public string NameRussian { get; set; }
        public string NameSpanish { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
        public int NumberRatings { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFriendly { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public FoodBusinessState FoodBusinessState { get; set; }
        public FoodBusinessCategory FoodBusinessCategory { get; set; }
        

    }
}