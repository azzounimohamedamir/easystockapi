namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDishSupplementDto
    {
        public string SupplementId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
