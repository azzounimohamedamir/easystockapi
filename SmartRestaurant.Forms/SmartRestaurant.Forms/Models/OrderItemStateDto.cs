using System;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Forms.Models;

namespace SmartRestaurant.Forms.ViewModels
{

    public class OrderItemStateDto:BaseModel
    {
        public OrderItemState State { get; set; }

        public string OrderItemName { get; set; }
        public string StateItemName { get;  set; }
        public string OrderItemId { get;  set; }
        public string Time { get; set; }

        public void ChangeState(OrderItemState state)
        {
            State = state;
            StateItemName = state.State.ToString();
            Time= State.SysDate.ToString("hh:mm");
        }
    }
}