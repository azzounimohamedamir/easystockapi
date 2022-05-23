using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;

namespace SmartRestaurant.Application.Common.Dtos.DishDtos
{
    public class DishSupplementDto
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
    }
}