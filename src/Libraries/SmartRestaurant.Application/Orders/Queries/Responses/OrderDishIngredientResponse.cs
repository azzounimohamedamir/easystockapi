namespace SmartRestaurant.Application.Orders.Queries.Responses
{
    public class OrderDishIngredientResponse
    {
        public string Name { get; set; }
        public float PriceValuePerStep { get; set; }
        public int Steps { get; set; }
    }
}