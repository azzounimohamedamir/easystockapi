using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Services.Models
{
    //OK
    public class OrderItemModel
    {       

        public OrderItemModel()
        {
            States = new List<OrderItemState>
            {
                new OrderItemState(DateTime.Now, EnumState.Waitting )
            };
            SysDate = DateTime.Now;
        }
        //Guid Auto
        public string Id { get; set; }

        public string RestaurantId { get; set; }
        
        public string PlaceId { get; set; }
        //Id of the Order Parent
        public string ParentId { get; set; }

        public string MenuItemId { get; set; } //MenuDishItemModel or MenuProductItemModel

        public bool IsProduct { get; set; }

        public List<IngredientModel> Ingredients { get; set; }

        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }

        public PriceModel Price { get; set; }
        public PriceModel TotalPrice { get; set; }

        public DateTime SysDate { get; private set; }
       
        //public IDictionary<DateTime, StateAndWhom> States { get; private set; }
        public List<OrderItemState> States { get; set; }

        public OrderItemModel AddState(OrderItemState state)
        {
            States.Add(state);
            return this;
        }

        public OrderItemState LastState
        {
            get
            {
                return States.OrderByDescending(s=>s.SysDate)
                     .FirstOrDefault();
            }

        }
    }

    public class OrderItemState
    {
        public OrderItemState()
        {

        }
        public OrderItemState(EnumState state)
        {
            SysDate = DateTime.Now;
            State = state;
        }
        public OrderItemState(DateTime sysdate, EnumState state)
        {
            SysDate = sysdate;
            State = state;
        }

        public OrderItemState(DateTime sysDate,
                              EnumState state,
                              EnumWhom whom,
                              string causes) : this(sysDate, state)
        {
            Whom = whom;
            Causes = causes;
        }

        public OrderItemState(DateTime sysDate,
                              EnumState state,
                              EnumWhom whom,
                              string userId,
                              string causes):this(sysDate,state,whom,causes)
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
