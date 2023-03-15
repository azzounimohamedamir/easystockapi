using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Orders.Queries.FilterStrategy
{
    public interface IOrderFilterStrategy
    {     
        public PagedResultBase<Order> FetchData(DbSet<Order> Dishes, GetOrdersListQuery request);
        public List<HotelOrder> FetchDataOfClientSH(DbSet<HotelOrder> hotelOrders, GetAllClientSHOrdersQuery request, string clientId);
        public List<HotelOrder> FetchDataOfManagerSH(DbSet<HotelOrder> hotelOrders, GetAllClientSHOrdersQuery request);

        public PagedResultBase<Order> FetchDataOfDinnerOrClient(DbSet<Order> Dishes, GetOrdersListByDinnerOrClientQuery request , string dinerId);
        public PagedResultBase<Order> FetchOrderListOfTodayOfDinner(DbSet<Order> Dishes, GetAllTodayOrdersQueryByTableId request);


    }
}
