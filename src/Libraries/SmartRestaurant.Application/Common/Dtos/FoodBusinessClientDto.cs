using System;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;


namespace SmartRestaurant.Application.Common.Dtos
{
    public class FoodBusinessClientDto
    {
        [JsonProperty(PropertyName = "id")] public Guid FoodBusinessClientId { get; set; }
        public string Name { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }

        public OdooDto Odoo { get; set; }
        public string Website { get; set; }
        public string ManagerId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public Boolean Archived { get; set; }
    }
}
