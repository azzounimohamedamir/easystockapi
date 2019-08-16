using System;

namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public class CreateQuantityModel
    {
        public Guid UniteId { get; set; }
        public decimal Value { get; set; }
    }
}