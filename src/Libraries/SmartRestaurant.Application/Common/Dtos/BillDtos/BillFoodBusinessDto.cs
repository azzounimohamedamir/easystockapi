using System;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillFoodBusinessDto
    {        
        public Guid FoodBusinessId { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }      
        public string Website { get; set; }
        public string Email { get; set; }
        public Currencies DefaultCurrency { get; set; }
    }
}