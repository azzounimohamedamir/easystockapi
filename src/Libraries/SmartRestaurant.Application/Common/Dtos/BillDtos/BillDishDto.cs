namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillDishDto
    {
        public string OrderDishId { get; set; }
        public string DishId { get; set; }
        public string Name { get; set; }
        public float InitialPrice { get; set; }
        public float UnitPrice { get; set; }
        public int Discount { get; set; }
        public float Quantity { get; set; }          
    }
}
