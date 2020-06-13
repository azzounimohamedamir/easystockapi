using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Services.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public int OrderNumber { get; private set; }
        
        public string RestaurantId { get; set; }
        public string FloorId { get; set; }
        public string AreaId { get; set; }
        public string TableId { get; set; }
        public string PlaceId { get; set; }

        public string ServiceId { get; set; }

        public GuestModel Guest { get; set; }
        public WaiterModel Waiter { get; set; }

        public OrderModel()
        {

            Id = Guid.NewGuid().ToString();            
            States = new List<OrderState>
            {
                new OrderState( DateTime.Now, EnumState.Waitting )
            };
            OrderItems = new List<OrderItemModel>();            
        }
        
        public List<OrderItemModel> OrderItems { get;  set; }
        
        public OrderModel RemoveItem(OrderItemModel item)
        {            
            OrderItems.Remove(item);            
            return this;
        }
        public OrderModel RemoveItem(string itemId)
        {
            var item = OrderItems.FirstOrDefault(it => it.Id == itemId);
            return RemoveItem(item);
        }

        public void AddItem(OrderItemModel item)
        {
            item.Id= Guid.NewGuid().ToString();
            item.RestaurantId = this.RestaurantId;
            item.ParentId = this.Id;
            item.PlaceId = this.PlaceId;
            item.AddState(new OrderItemState(DateTime.Now, EnumState.Waitting));
            OrderItems.Add(item);
        }

        public void AddRangeItems(List<OrderItemModel> items)=>items.ForEach(it => AddItem(it));

        public List<OrderState> States { get; private set; }

        public void AddState(OrderState state)
        {
            States.Add(state);
        }

        public OrderState LastState
        {
            get
            {
               return States.OrderByDescending(s=>s.SysDate)
                    .FirstOrDefault();                
            }
            
        }

        public bool HasProducts => OrderItems?.Any(it => it.IsProduct)??false;
        public List<OrderItemModel> Products => OrderItems?.Where(it => it.IsProduct).ToList() ?? null;


    }
    
    public class OrderState
    {
        public OrderState()
        {

        }
        public OrderState(DateTime sysdate, EnumState state)
        {
            SysDate = sysdate;
            State = state;
        }

        public OrderState(DateTime sysDate,
                              EnumState state,
                              EnumWhom whom,
                              string causes) : this(sysDate, state)
        {
            Whom = whom;
            Causes = causes;
        }

        public OrderState(DateTime sysDate,
                              EnumState state,
                              EnumWhom whom,
                              string userId,
                              string causes) : this(sysDate, state, whom, causes)
        {

            UserId = userId;

        }

        public DateTime SysDate { get; set; }
        public EnumState State { get; set; }

        public EnumWhom Whom { get; set; }
        public string UserId { get; set; }
        public string Causes { get; set; }
    }

}
