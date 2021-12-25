namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillProductDto
    {
        public string OrderProductId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public float InitialPrice { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public float Quantity { get; set; }
    }
}
