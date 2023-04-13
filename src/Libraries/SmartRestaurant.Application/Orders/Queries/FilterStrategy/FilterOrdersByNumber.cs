using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
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
                       .ThenInclude(o=>o.ComboBoxContentTranslation)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       .Include(o => o.CommissionConfigs)
                       .Include(o => o.FoodBusinessClient)
                       .Where(ConditionForStaff(request))
                       .OrderByDescending(orders => orders.Status)
                       .ThenByDescending(orders => orders.CreatedAt)
                       .AsNoTracking()
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return orders
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Specifications)
                       .ThenInclude(o =>o.ComboBoxContentTranslation)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       .Include(o => o.FoodBusinessClient)
                       .Where(ConditionForStaff(request))
                       .OrderBy(orders => orders.Status)
                       .ThenByDescending(orders => orders.CreatedAt)
                       .AsNoTracking()
                       .GetPaged(request.Page, request.PageSize);
            }
        }
        public PagedResultBase<Order> FetchDataOfDinnerOrClient(DbSet<Order> orders, GetOrdersListByDinnerOrClientQuery request , string dinerId)
        {
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;
            switch (sortOrder)
            {
                case "desc":
                    return orders
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Specifications)
                       .ThenInclude(o => o.ComboBoxContentTranslation)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       
                       .Where(ConditionForClient(request,dinerId))
                       .OrderByDescending(orders => orders.Status)
                       .ThenByDescending(orders => orders.CreatedAt)
                       .AsNoTracking()
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return orders
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Specifications)
                       .ThenInclude(o => o.ComboBoxContentTranslation)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       .Where(ConditionForClient(request,dinerId))
                       .OrderBy(orders => orders.Status)
                       .ThenByDescending(orders => orders.CreatedAt)
                       .AsNoTracking()
                       .GetPaged(request.Page, request.PageSize);
            }
        }
        private static Expression<Func<Order, bool>> ConditionForStaff(GetOrdersListQuery request)
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

        private static Expression<Func<Order, bool>> FetchOrderListOfTodayOfDinnerConditions(GetAllTodayOrdersQueryByTableId request)
        {
            if (string.IsNullOrWhiteSpace(request.SearchKey))
            {
                return order =>
                      
                     (order.CreatedAt).Date == DateTime.Today.Date
                     ;
            }
            else
            {
                var searchKey = ChecksHelper.IsFloatNumber(request.SearchKey) ? float.Parse(request.SearchKey) : -1.0;
                return order =>
                      order.CreatedAt == DateTime.Today &&
                      order.Number == searchKey;
            }
        }


        public PagedResultBase<Order> FetchOrderListOfTodayOfDinner(DbSet<Order> orders, GetAllTodayOrdersQueryByTableId request)
        {
           
                    return orders
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Specifications)
                       .ThenInclude(o => o.ComboBoxContentTranslation)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Ingredients)
                       .Include(o => o.Dishes)
                       .ThenInclude(o => o.Supplements)
                       .Include(o => o.Products)
                       .Include(o => o.OccupiedTables)
                       .Where(FetchOrderListOfTodayOfDinnerConditions(request))
                       .OrderByDescending(orders => orders.Status)
                       .ThenByDescending(orders => orders.CreatedAt)
                       .AsNoTracking()
                       .GetPaged(request.Page, request.PageSize);

        }


        public List<HotelOrder> FetchDataOfClientSH(DbSet<HotelOrder> hotelOrders, GetAllClientSHOrdersQuery request , string clientId)
        {

            return hotelOrders
               .Include(ho => ho.ParametreValueClient)
               .Where(ho => ho.UserId == Guid.Parse(clientId))
               .OrderByDescending(ho => ho.DateOrder).AsNoTracking().ToList();

        }

        public List<HotelOrder> FetchDataOfManagerSH(DbSet<HotelOrder> hotelOrders, GetAllClientSHOrdersQuery request)
        {

            return hotelOrders
               .Include(ho => ho.ParametreValueClient)
               .OrderByDescending(ho => ho.DateOrder)
               .AsNoTracking().ToList();

        }

        private static Expression<Func<Order, bool>> ConditionForClient(GetOrdersListByDinnerOrClientQuery request,string dinerId)
        {
            if (string.IsNullOrWhiteSpace(request.SearchKey))
            {
                return order =>
                     order.CreatedBy==dinerId &&
                     order.CreatedAt >= FiltersHelpers.GetDateFilter(request.DateInterval);
            }
            else
            {
                var searchKey = ChecksHelper.IsFloatNumber(request.SearchKey) ? float.Parse(request.SearchKey) : -1.0;
                return order =>
                     order.CreatedBy == dinerId &&
                     order.CreatedAt >= FiltersHelpers.GetDateFilter(request.DateInterval)
                    && order.Number == searchKey;
            }
        }

    }
}
