using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Services.Models
{

    public class CanceledOrderItemModel
    {
        public EnumWhom Whom { get; set; }
        public OrderItemModel ItemModel { get; set; }
        public string UserId { get; set; }
        public string Causes { get; set; }
    }

    public class CanceledOrderModel
    {
        public EnumWhom Whom { get; set; }
        public OrderModel Order { get; set; }
        public string UserId { get; set; }
        public string Causes { get; set; }
    }


}
