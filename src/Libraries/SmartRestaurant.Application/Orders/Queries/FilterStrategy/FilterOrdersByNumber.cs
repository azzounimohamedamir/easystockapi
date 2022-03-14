using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Orders.Queries.FilterStrategy
{
    public class FilterOrdersByNumber : IOrderFilterStrategy
    {
        public PagedResultBase<Order> FetchData(DbSet<Order> orders, GetOrdersListQuery request)
        {
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "desc":
                    return orders
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Specifications)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       .Where(Condition(request))
                       .OrderByDescending(orders => orders.Status)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return orders
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Specifications)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       .Where(Condition(request))
                       .OrderBy(orders => orders.Status)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        private static Expression<Func<Order, bool>> Condition(GetOrdersListQuery request)
        {
            if(string.IsNullOrWhiteSpace(request.SearchKey))
            {
                return order =>
                       order.FoodBusinessId == Guid.Parse(request.FoodBusinessId)
                    && order.CreatedAt >= FiltersHelpers.GetDateFilter(request.DateInterval);
            }
            else
            {              
                var searchKey = ChecksHelper.IsFloatNumber(request.SearchKey) ? float.Parse(request.SearchKey) : -1.0;
                return order =>
                       order.FoodBusinessId == Guid.Parse(request.FoodBusinessId)
                    && order.CreatedAt >= FiltersHelpers.GetDateFilter(request.DateInterval)
                    && order.Number == searchKey;
            }
        }        
    }
}
