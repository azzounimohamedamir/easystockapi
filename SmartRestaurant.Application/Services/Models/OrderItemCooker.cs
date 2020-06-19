using SmartRestaurant.Application.Restaurants.Staffs.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Services.Models
{
    //public class OrderStaff
    //{

    //    public OrderModel Order { get; set; }
    //    public CookerModel Cooker { get; set; }
    //}

    public class OrderItemCookerModel
    {
        public OrderItemModel OrderItem { get; set; }
        public CookerModel Cooker { get; set; }
    }
}
