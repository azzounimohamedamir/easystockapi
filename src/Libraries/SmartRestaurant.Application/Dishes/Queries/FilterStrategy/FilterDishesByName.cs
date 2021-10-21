using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Dishes.Queries.FilterStrategy
{
    public class FilterDishesByName : IDishFilterStrategy
    {
        public PagedResultBase<Dish> FetchData(DbSet<Dish> dishes, GetDishesListQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return dishes
                       .Include(x => x.Ingredients)
                       .ThenInclude(x => x.Ingredient)
                       .Include(x => x.Supplements)
                       .ThenInclude(x => x.Supplement)
                       .Include(x => x.Specifications)
                       .Where(Condition(request.FoodBusinessId, searchKey))
                       .OrderBy(dish => dish.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return dishes
                       .Include(x => x.Ingredients)
                       .ThenInclude(x => x.Ingredient)
                       .Include(x => x.Supplements)
                       .ThenInclude(x => x.Supplement)
                       .Include(x => x.Specifications)
                       .Where(Condition(request.FoodBusinessId, searchKey))
                       .OrderByDescending(dish => dish.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return dishes
                       .Include(x => x.Ingredients)
                       .ThenInclude(x => x.Ingredient)
                       .Include(x => x.Supplements)
                       .ThenInclude(x => x.Supplement)
                       .Include(x => x.Specifications)
                       .Where(Condition(request.FoodBusinessId, searchKey))
                       .OrderBy(dish => dish.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        private static Expression<Func<Dish, bool>> Condition(string foodBusinessId, string searchKey)
        {
            if(foodBusinessId == null)
                return dish => dish.Name.Contains(searchKey) && dish.FoodBusinessId == null;
            else 
                return dish => dish.Name.Contains(searchKey) && dish.FoodBusinessId == Guid.Parse(foodBusinessId);
        }

    }
}
