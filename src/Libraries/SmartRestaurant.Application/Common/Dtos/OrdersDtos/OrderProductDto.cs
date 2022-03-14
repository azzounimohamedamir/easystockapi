namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public float EnergeticValue { get; set; }
        public string Description { get; set; }
        public string TableId { get; set; }
        public int TableNumber { get; set; }
        public int ChairNumber { get; set; }
        public float Quantity { get; set; }
    }
}
