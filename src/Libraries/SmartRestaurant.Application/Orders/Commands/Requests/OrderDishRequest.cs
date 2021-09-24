using System.Collections.Generic;

namespace SmartRestaurant.Application.Orders.Commands.Requests
{
    public class OrderDishRequest
    {
        public string Name { get; set; }
        public float PriceValue { get; set; }
        public List<OrderDishIngredientRequest> OrderDishIngredients { get; set; }
    }
}