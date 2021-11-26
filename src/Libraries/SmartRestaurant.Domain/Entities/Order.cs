using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public float TotalToPay { get; set; }
        public float MoneyReceived { get; set; }
        public float MoneyReturned { get; set; }
        public OrderTypes Type { get; set; }
        public OrderStatuses Status { get; set; }
        public TakeoutDetails TakeoutDetails { get; set; }      
        public virtual List<OrderDish> Dishes { get; set; }
        public virtual List<OrderProduct> Products { get; set; }
        public virtual List<OrderOccupiedTable> OccupiedTables { get; set; }        
        public Guid FoodBusinessId { get; set; }
        public virtual FoodBusiness FoodBusiness { get; set; }
        public Guid? FoodBusinessClientId { get; set; }
        public virtual FoodBusinessClient FoodBusinessClient { get; set; }

    }
}