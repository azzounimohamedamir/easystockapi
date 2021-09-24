using System.Collections.Generic;

namespace SmartRestaurant.Application.Orders.Queries.Responses
{
    public class OrderDishResponse
    {
        public string Name { get; set; }
        public float PriceValue { get; set; }
        public List<OrderDishIngredientResponse> OrderDishIngredients { get; set; }
    }
}