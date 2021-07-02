using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

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
        public List<string> Tags { get; set; }
        public string Website { get; set; }
        public FoodBusinessState FoodBusinessState { get; set; }
        public List<string> Images { get; set; }
    }
}