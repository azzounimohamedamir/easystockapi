using System.Collections.Generic;

namespace SmartRestaurant.Application.Services.Models
{
    public class OrderUpdateModel
    {
        public string OrderId { get; set; }
        public string State { get; set; }
        public string Time { get; set; }

        public List<OrderItemUpdateModel> Items { get; set; }
    }
    public class OrderItemUpdateModel
    {
        public string OrderItemId { get; set; }
        public string State { get; set; }
        public string Time { get; set; }
    }
}
