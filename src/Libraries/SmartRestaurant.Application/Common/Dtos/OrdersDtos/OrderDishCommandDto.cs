using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDishCommandDto
    {
        public string DishId { get; set; }
        public string Name { get; set; }
        public float InitialPrice { get; set; }
        public float EnergeticValue { get; set; }
        public string Description { get; set; }
        public int EstimatedPreparationTime { get; set; }
        public string TableId { get; set; }
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public float Quantity { get; set; }
        public List<OrderDishSpecificationDto> Specifications { get; set; }
        public List<OrderDishIngredientDto> Ingredients { get; set; }
        public List<OrderDishSupplementDto> Supplements { get; set; }
    }
}
