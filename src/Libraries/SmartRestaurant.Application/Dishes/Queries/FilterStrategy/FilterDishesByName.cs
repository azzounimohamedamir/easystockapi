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
                       .Where(Condition(request.FoodBusinessId, request.IsSupplement, searchKey))
                       .OrderBy(dish => dish.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return dishes
                       .Include(x => x.Ingredients)
                       .ThenInclude(x => x.Ingredient)
                       .Include(x => x.Supplements)
                       .ThenInclude(x => x.Supplement)
                       .Include(x => x.Specifications)
                       .Where(Condition(request.FoodBusinessId, request.IsSupplement, searchKey))
                       .OrderByDescending(dish => dish.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return dishes
                       .Include(x => x.Ingredients)
                       .ThenInclude(x => x.Ingredient)
                       .Include(x => x.Supplements)
                       .ThenInclude(x => x.Supplement)
                       .Include(x => x.Specifications)
                       .Where(Condition(request.FoodBusinessId, request.IsSupplement, searchKey))
                       .OrderBy(dish => dish.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        private static Expression<Func<Dish, bool>> Condition(string foodBusinessId, Nullable<bool> isSupplement, string searchKey)
        {
            if(foodBusinessId == null && isSupplement == null)
                return dish => dish.Name.Contains(searchKey) && dish.FoodBusinessId == null;

            else if (foodBusinessId == null && isSupplement != null)
                return dish => dish.Name.Contains(searchKey) && dish.FoodBusinessId == null && dish.IsSupplement == isSupplement;

            else if (foodBusinessId != null && isSupplement == null)
                return dish => dish.Name.Contains(searchKey) && dish.FoodBusinessId == Guid.Parse(foodBusinessId);

            else
                return dish => dish.Name.Contains(searchKey) && dish.FoodBusinessId == Guid.Parse(foodBusinessId) && dish.IsSupplement == isSupplement;
        }

    }
}
