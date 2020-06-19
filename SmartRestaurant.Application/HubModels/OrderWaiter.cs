using SmartRestaurant.Application.Services.Models;

namespace SmartRestaurant.Application.HubModels
{
    public class OrderWaiter
    {
        public OrderWaiter()
        {
            OrderItem = new OrderItemModel();
            waiter = new WaiterModel();
        }
        public OrderItemModel OrderItem { get; set; }
        public WaiterModel waiter { get; set; }

    }
}