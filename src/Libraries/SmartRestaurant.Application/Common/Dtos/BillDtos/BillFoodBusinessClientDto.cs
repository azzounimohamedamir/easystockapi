using System;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;

namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillFoodBusinessClientDto
    {
        public Guid FoodBusinessClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}
