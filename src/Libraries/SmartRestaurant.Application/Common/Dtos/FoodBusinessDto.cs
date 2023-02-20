using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FoodBusinessDto
    {
        public FoodBusinessDto()
        {
            Images = new List<string>();
        }

        [JsonProperty(PropertyName = "id")] public Guid FoodBusinessId { get; set; }

        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFriendly { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public bool AcceptDelivery { get; set; }

        public List<string> Tags { get; set; }
        public string Website { get; set; }
        public FoodBusinessState FoodBusinessState { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public FoodBusinessCategory FoodBusinessCategory { get; set; }
        public List<string> Images { get; set; }
        public int zonesCount { get; set; }
        public int tablesCount { get; set; }
        public int menusCount { get; set; }
        public int FourDigitCode { get; set; }
        public Currencies DefaultCurrency { get; set; }
        public CommissionConfigs CommissionConfigs { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string NearbyLocationDescription { get; set; }
        public decimal NearbyLocationPrice { get; set; }
        public string FarLocationDescription { get; set; }
        public decimal FarLocationPrice { get; set; }
        public bool IsActivityFrozen { get; set; }
      

        public string Logo { get; set; }
        public List<FoodBusinessUserRatingDto> Ratings { get; set; }
        public int CurrentUserRating { get; set; }
    }
}