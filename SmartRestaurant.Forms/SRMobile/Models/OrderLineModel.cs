namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage dish currencies
    /// </summary>
    public class OrderLineModel
    {
        public int Index { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public float LineTotal { get; set; }
    }
}
