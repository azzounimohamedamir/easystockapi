using Microsoft.AspNetCore.SignalR;
using SmartRestaurant.Application.HubModels;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Hubs
{
    public class Place
    {
        public string Id { get; set; }
        public string TableId { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    public class Waiter
    {
        public string Id { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    public class OrderHub : Hub
    {
        private static readonly ConcurrentDictionary<string, Waiter> Waiters
        = new ConcurrentDictionary<string, Waiter>();
        private static IDictionary<string, OrdersManager> OrdersManager
           = new Dictionary<string, OrdersManager>();

        public override Task OnConnectedAsync()
        {
            var user = Context.User;

            if (user.IsInRole(Enum.GetName(typeof(EnumPersoneType), EnumPersoneType.Waiter)))
            {
                var claims = (ClaimsIdentity)user.Claims;
                string waiterId = claims.FindFirst("Id").Value;

                string connectionId = Context.ConnectionId;

                var waiter = Waiters.GetOrAdd(waiterId, _ => new Waiter
                {
                    Id = waiterId,
                    ConnectionIds = new HashSet<string>()
                });

                lock (waiter.ConnectionIds)
                {
                    waiter.ConnectionIds.Add(connectionId);
                }

            }
            else
            {

            }

            return base.OnConnectedAsync();
        }
        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }



        public override Task OnDisconnectedAsync(Exception exception)
        {
            //Disconnect waiter
            return base.OnDisconnectedAsync(exception);
        }
        /// <summary>
        /// Liste des OrdersManager par restaurant
        /// </summary>

        private async Task<OrdersManager> GetOrdersManagerAsync(string restaurantId)
        {
            await AddGroup(restaurantId);
            var restaurantOrders = OrdersManager.FirstOrDefault(x => x.Key == restaurantId).Value;
            if (restaurantOrders == null)
            {
                restaurantOrders = new OrdersManager();
                OrdersManager.Add(restaurantId, restaurantOrders);
            }

            return restaurantOrders;
        }

        public async Task AddGroup(string restaurantId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, restaurantId);
        }

        public async Task RemoveGroup(string restaurantId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, restaurantId);
        }

        public async Task PushOrder(OrderModel order)
        {
            try
            {
                var restaurantOrders = await GetOrdersManagerAsync(order.RestaurantId);
                restaurantOrders.PushOrder(order);

                await Clients.Group(order.RestaurantId).SendAsync("newOrder", order);
                //await Clients.All.SendAsync("newOrder", order);
                ///// FeedBack
                //foreach (var item in order.OrderItems)
                //{
                //    await FeedBackItem(item , id );
                //}
                await AddGroup(order.PlaceId);

                if (order.HasProducts) await ReadyToServeItems(order.Products);

            }
            catch (Exception)
            {

            }
        }

        //Webonly Chef affectation des tâches au cuisiniers
        public async Task AssignOrderItem(OrderItemModel orderItem, CookerModel cooker)
        {
            var restaurantOrders = await GetOrdersManagerAsync(orderItem.RestaurantId);
            restaurantOrders.AssignOrderItem(orderItem, cooker);
            /// FeedBack 
            await Clients.Group(orderItem.PlaceId).SendAsync("feedBack", orderItem.Id, orderItem.LastState);

            await Clients.Group(orderItem.RestaurantId).SendAsync("newCookerTask", orderItem);

        }

        public async Task ReadyToServeItems(List<OrderItemModel> orderItems)
        {
            foreach (var item in orderItems)
                await ReadyToServe(item);
        }

        public async Task ReadyToServe(OrderItemModel orderItem)
        {
            var restaurantOrders = await GetOrdersManagerAsync(orderItem.RestaurantId);

            restaurantOrders.ReadyToServe(orderItem, out string waiterId);
            /// FeedBack 
            await Clients.Group(orderItem.PlaceId).SendAsync("feedBack", orderItem.Id, orderItem.LastState);
            //await Clients.User(waiterId).SendAsync("DishReady", orderItem);
            var waiter = Waiters.FirstOrDefault(x => x.Key == waiterId);
            foreach (string cid in waiter.Value.ConnectionIds)
            {
                await Clients.Client(cid).SendAsync("orderItemReady", orderItem);
            }
        }

        public async Task DelivredOrder(OrderItemModel orderItem)
        {

            var restaurantOrders = await GetOrdersManagerAsync(orderItem.RestaurantId);

            restaurantOrders.DelivredOrder(orderItem);
            /// FeedBack 
            await Clients.Group(orderItem.PlaceId).SendAsync("feedBack", orderItem.Id, orderItem.LastState);
            await Clients.Group(orderItem.RestaurantId).SendAsync("orderItemDelivred", orderItem);
        }

        public async Task CanceledOrderItem(CanceledOrderItemModel canceledOrderItem)
        {
            string restaurantId = canceledOrderItem.ItemModel.RestaurantId;
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);

            restaurantOrders.CanceledOrderItem(canceledOrderItem);
            /// FeedBack 
            await Clients.Group(restaurantId).SendAsync("orderItemCanceled", canceledOrderItem);

            await Clients.Caller.SendAsync("feedBack", canceledOrderItem.ItemModel.Id, canceledOrderItem.ItemModel.LastState);
        }

        public async Task CanceledOrder(CanceledOrderModel canceledorder)
        {
            string restaurantId = canceledorder.Order.RestaurantId;
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);

            restaurantOrders.CanceledOrder(canceledorder);
            await Clients.Group(restaurantId).SendAsync("orderCanceled", canceledorder);

            await Clients.Caller.SendAsync("orderCanceled", canceledorder);

        }

        public async Task PaidOrderItem(OrderItemModel orderItem)
        {
            string restaurantId = orderItem.RestaurantId;
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            restaurantOrders.PaidOrderItem(orderItem);
            await Clients.Group(restaurantId).SendAsync("paidOrderItem", orderItem);
        }

        public async Task PaidOrder(OrderModel order)
        {
            string restaurantId = order.RestaurantId;
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            restaurantOrders.PaidOrder(order);
            await Clients.Group(restaurantId).SendAsync("paidOrder", order);
        }

        public async Task FreeOrderItem(FreeOrderItemModel freeOrderItem)
        {
            string restaurantId = freeOrderItem.ItemModel.RestaurantId;
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            restaurantOrders.FreeOrderItem(freeOrderItem);

            await Clients.Group(restaurantId).SendAsync("freeOrderItem", freeOrderItem);
        }

        public async Task FreeOrder(FreeOrderModel freeOrder)
        {
            string restaurantId = freeOrder.Order.RestaurantId;
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            restaurantOrders.FreeOrder(freeOrder);

            await Clients.Group(restaurantId).SendAsync("freeOrder", freeOrder);
        }
 
        #region Refresh

        public async Task RefreshClientsOrders(string restaurantId)
        {
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            await Clients.Group(restaurantId).SendAsync("ClientsOrderRefreshed", restaurantOrders.InProgressOrders);
        }
        public async Task RefreshSignedOrders(string restaurantId)
        {
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            await Clients.Group(restaurantId).SendAsync("SignedOrdersRefresh", restaurantOrders.InProgressOrders);
        }
        public async Task RefreshReadyOrders(string restaurantId, string waiterId)
        {
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            var waiter = Waiters.FirstOrDefault(x => x.Key == waiterId);
            var ready = restaurantOrders.ReadyToServeOrders.Where(x => x.waiter.Id == waiterId);
            foreach (string cid in waiter.Value.ConnectionIds)
            {
                await Clients.Client(cid).SendAsync("ReadyOrdersRefreshed", ready);
            }
         }
        public async Task RefreshDeliveredOrders(string restaurantId)
        {
            var restaurantOrders = await GetOrdersManagerAsync(restaurantId);
            await Clients.Group(restaurantId).SendAsync("DeliveredOrdersRefresh", restaurantOrders.InProgressOrders);
        }

        #endregion
    }
}
