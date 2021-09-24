namespace SmartRestaurant.Application.Orders.Commands.Requests
{
    public class OrderDishIngredientRequest
    {
        public string Name { get; set; }
        public float PriceValuePerStep { get; set; }
        public int Steps { get; set; }
    }
}