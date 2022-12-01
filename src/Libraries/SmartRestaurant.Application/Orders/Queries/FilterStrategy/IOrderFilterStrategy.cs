using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Orders.Queries.FilterStrategy
{
    public interface IOrderFilterStrategy
    {     
        public PagedResultBase<Order> FetchData(DbSet<Order> Dishes, GetOrdersListQuery request);
        public PagedResultBase<Order> FetchDataOfDinnerOrClient(DbSet<Order> Dishes, GetOrdersListByDinnerOrClientQuery request , string dinerId);

    }
}
