using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Menus.Queries.FilterStrategy
{
    public class FilterMenusByName : IMenuFilterStrategy
    {
        public PagedResultBase<Menu> FetchData(DbSet<Menu> menus, GetMenusListQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return menus
                       .Where(Condition(request.FoodBusinessId, searchKey))
                       .OrderBy(menu => menu.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return menus
                       .Where(Condition(request.FoodBusinessId, searchKey))
                       .OrderByDescending(menu => menu.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return menus
                       .Where(Condition(request.FoodBusinessId, searchKey))
                       .OrderBy(menu => menu.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        private static Expression<Func<Menu, bool>> Condition(string foodBusinessId, string searchKey)
        {
            if(foodBusinessId == null)
                return menu => menu.Name.Contains(searchKey) && menu.FoodBusinessId == null;
            else 
                return menu => menu.Name.Contains(searchKey) && menu.FoodBusinessId == Guid.Parse(foodBusinessId);
        }

    }
}
