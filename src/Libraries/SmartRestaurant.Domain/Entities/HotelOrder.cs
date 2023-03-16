using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Common.Enums;
using SmartRestaurant.Domain.Enums;

using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class HotelOrder 
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CheckinId { get; set; }
        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }

        public Names Names { get; set; }
        public DateTime DateOrder { get; set; }
        public OrderTypes Type { get; set; }
        public Guid TableId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public int ChairNumber { get; set; }
        public List<ParametresValue> ParametreValueClient { get; set; }

        public bool IsSmartrestaurantMenue { get; set; }
        public Guid SmartRestaurentOrderId { get; set; }

        public SHOrderStat OrderStat { get; set; }

        public Room Room { get; set; }
        public CheckIn CheckIn { get; set; }
        public Hotel Hotel { get; set; }

        public Names SuccesMessage { get; set; }
        public Names FailureMessage { get; set; }

        public string ServiceManagerName { get; set; }
    }
}
