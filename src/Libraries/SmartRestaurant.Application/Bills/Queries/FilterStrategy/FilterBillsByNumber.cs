using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Bills.Queries.FilterStrategy
{
    public class FilterBillsByNumber : IBillFilterStrategy
    {
        public PagedResultBase<Order> FetchData(DbSet<Order> orders, GetBillsListQuery request)
        {
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "desc":
                    return orders
                       .Include(o => o.Dishes)
                       .Include(o => o.Products)
                       .Include(o => o.FoodBusiness)
                       .Include(o => o.FoodBusinessClient)
                       .Where(Condition(request))
                       .OrderByDescending(orders => orders.Status)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return orders
                       .Include(o => o.Dishes)
                       .Include(o => o.Products)
                       .Include(o => o.FoodBusiness)
                       .Include(o => o.FoodBusinessClient)
                       .Where(Condition(request))
                       .OrderBy(orders => orders.Status)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        private static Expression<Func<Order, bool>> Condition(GetBillsListQuery request)
        {
            if(string.IsNullOrWhiteSpace(request.SearchKey))
            {
                return order =>
                       order.FoodBusinessId == Guid.Parse(request.FoodBusinessId)
                    && order.CreatedAt >= FiltersHelpers.GetDateFilter(request.DateInterval)
                    && order.Status != OrderStatuses.Cancelled;
            }
            else
            {              
                var searchKey = ChecksHelper.IsFloatNumber(request.SearchKey) ? float.Parse(request.SearchKey) : -1.0;
                return order =>
                       order.FoodBusinessId == Guid.Parse(request.FoodBusinessId)
                    && order.CreatedAt >= FiltersHelpers.GetDateFilter(request.DateInterval)
                    && order.Status != OrderStatuses.Cancelled
                    && order.Number == searchKey;
            }
        }        
    }
}
