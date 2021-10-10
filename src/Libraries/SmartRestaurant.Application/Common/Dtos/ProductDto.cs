using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ProductDto
    {    
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public string FoodBusinessId { get; set; }

    }
}
