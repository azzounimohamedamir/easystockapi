using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.HubModels
{  
    public class OrdersManager
    {
        int orders;
        public List<OrderModel> Orders { get; set; }  
        
        public List<OrderItemCookerModel> InProgressOrders { get; set; }

        public List<OrderWaiter> ReadyToServeOrders { get; set; }

        public List<OrderItemModel> DelivredOrders { get; set; }
                

        public OrdersManager()
        {
            InitOrdersManager();
        }

        public void InitOrdersManager()
        {
            Orders = new List<OrderModel>();
            InProgressOrders = new List<OrderItemCookerModel>();
            ReadyToServeOrders = new List<OrderWaiter>();
            DelivredOrders = new List<OrderItemModel>();            
        }
        
        public OrdersManager PushOrder(OrderModel order)
        {   
            Orders.Add(order);
            var products = order.OrderItems.Where(it => it.IsProduct).ToList();
            if (products != null && products.Count > 0)
                products.ForEach(
                     p =>
                     {
                         p.AddState(new OrderItemState(EnumState.Ready));
                         ReadyToServeOrders.Add(new OrderWaiter
                         {
                             waiter =order.Waiter,
                             OrderItem=p                             
                         });
                     });
            
            return this;
        }
        
        public OrdersManager AssignOrderItem(OrderItemModel orderItem,CookerModel cooker )
        {
            if (orderItem.LastState.State == EnumState.Canceled) return this;

            var CurrentProgressOrder = new OrderItemCookerModel()
            {
                Cooker  = cooker,
                OrderItem = orderItem.AddState(
                    new OrderItemState(DateTime.Now, EnumState.InProgress))
            };

            var prevOrderItem = InProgressOrders.FirstOrDefault
                (
                x => x.Cooker.Id == cooker.Id
                );
            
            if (prevOrderItem != null)
            {
                if (prevOrderItem.OrderItem != null)
                {
                    ReadyToServe(prevOrderItem.OrderItem,out string waiterId);
                    InProgressOrders.Remove(prevOrderItem);
                }
            }

            InProgressOrders.Add(CurrentProgressOrder);
            prevOrderItem = CurrentProgressOrder;
                        
            var order = Orders
                .FirstOrDefault(or => or.Id == orderItem.ParentId);
            //InProcess
            if(order.States.All(st=>st.State!= EnumState.InProgress))
            {
                order.AddState(new OrderState(DateTime.Now, EnumState.InProgress));
            }            
            return this;
        }
       
        public OrdersManager ReadyToServe(OrderItemModel item,out string WaiterId)
        {
            WaiterId = string.Empty;
            if (item.LastState.State == EnumState.Canceled) return this;

            var order = Orders
                .FirstOrDefault(or => or.Id == item.ParentId);
                       
            var orderwaiter = new OrderWaiter()
            {
                OrderItem = item.AddState(new OrderItemState(DateTime.Now, EnumState.Ready)),
                waiter = order.Waiter,
            };

            ReadyToServeOrders.Add(orderwaiter);

            if (order.OrderItems.All(it => it.States.Any(ist=>ist.State==EnumState.Ready)))
                order.AddState(new OrderState(DateTime.Now, EnumState.Ready));

            WaiterId = orderwaiter.waiter.Id;

            return this;
        }       

        public OrdersManager DelivredOrder(OrderItemModel item)
        {
            if (item.LastState.State == EnumState.Canceled) return this;

            DelivredOrders.Add(item);
            var order = Orders
                .FirstOrDefault(or => or.Id == item.ParentId);

            if (order.OrderItems.All(it => it.States.Any(ist => ist.State == EnumState.Delivred)))
                order.AddState(new OrderState(DateTime.Now, EnumState.Delivred));
            return this;

        }

        public OrdersManager CanceledOrderItem(CanceledOrderItemModel item)
        {
            if (item.ItemModel.LastState.State == EnumState.Canceled) return this;

            var order = Orders
               .FirstOrDefault(or => or.Id == item.ItemModel.ParentId);

            if (item.ItemModel.LastState.State != EnumState.Waitting) return this;
            item.ItemModel.AddState(new OrderItemState(DateTime.Now, EnumState.Canceled, item.Whom, item.UserId, item.Causes)) ;

            if (order.OrderItems.All(it => it.States.Any(ist => ist.State == EnumState.Canceled)))
                order.AddState(new OrderState(DateTime.Now, EnumState.Canceled, item.Whom, item.UserId, item.Causes));

            return this;
        }

        public OrdersManager CanceledOrder(CanceledOrderModel cancelOrder)
        {
            if (cancelOrder.Order.LastState.State == EnumState.Canceled) return this;

            cancelOrder.Order.OrderItems
                .ForEach(it => CanceledOrderItem(new CanceledOrderItemModel
                {
                    ItemModel=it,
                    Whom=cancelOrder.Whom,
                    Causes=cancelOrder.Causes,
                    UserId=cancelOrder.UserId,
                }));
            return this;
        }

        public OrdersManager PaidOrderItem(OrderItemModel item)
        {
            if (item.LastState.State == EnumState.Canceled) return this;
            var order = Orders
               .FirstOrDefault(or => or.Id == item.ParentId);

            if (item.LastState.State != EnumState.Delivred & ( item.LastState.State == EnumState.Paid || item.LastState.State == EnumState.Free)) return this;

            item.AddState(new OrderItemState(DateTime.Now, EnumState.Paid));

            if (order.OrderItems.All(it => it.States.Any(ist => ist.State == EnumState.Paid || ist.State==EnumState.Free)))
                order.AddState(new OrderState(DateTime.Now, EnumState.Paid));
            return this;
        }

        public OrdersManager PaidOrder(OrderModel order)
        {
            if (order.LastState.State == EnumState.Canceled) return this;
            order.OrderItems
                .ForEach(it => PaidOrderItem(it));
            return this;
        }

        public OrdersManager FreeOrderItem(FreeOrderItemModel freeOrderItem)
        {
            if (freeOrderItem.ItemModel.LastState.State == EnumState.Canceled) return this;

            var order = Orders
               .FirstOrDefault(or => or.Id == freeOrderItem.ItemModel.ParentId);

            if (freeOrderItem.ItemModel.LastState.State != EnumState.Delivred & freeOrderItem.ItemModel.LastState.State == EnumState.Free) return this;
            
            freeOrderItem.ItemModel.AddState(new OrderItemState(DateTime.Now, EnumState.Free, freeOrderItem.Whom, freeOrderItem.UserId, freeOrderItem.Causes));

            if (order.OrderItems.All(it => it.States.Any(ist => ist.State == EnumState.Free)))
                order.AddState(new OrderState(DateTime.Now, EnumState.Free, freeOrderItem.Whom, freeOrderItem.UserId, freeOrderItem.Causes));
            return this;
        }

        public OrdersManager FreeOrder(FreeOrderModel freeOrder)
        {
            if (freeOrder.Order.LastState.State == EnumState.Canceled) return this;

            freeOrder.Order.OrderItems
                .ForEach(it => FreeOrderItem(new FreeOrderItemModel
                {
                    ItemModel = it,
                    Whom = freeOrder.Whom,
                    Causes = freeOrder.Causes,
                    UserId = freeOrder.UserId,
                }));
            return this;
        }

        public OrderItemUpdateModel GetOrderItemUpdate(string itemId)
        {
            var order = Orders.FirstOrDefault(or => or.Id == or.OrderItems
            .FirstOrDefault(it => it.Id == itemId).ParentId);
            var item = order.OrderItems.FirstOrDefault(it => it.Id == itemId);

            return new OrderItemUpdateModel
            {
                OrderItemId = itemId,
                State = item.LastState.State.ToString(),
            };
        }

        public OrderUpdateModel GetOrderUpdate(string orderId)
        {
            return new OrderUpdateModel
            {
                OrderId = orderId,
                State = Orders.FirstOrDefault(or => or.Id == orderId).LastState.State.ToString(),
            };
        }
    }
}
