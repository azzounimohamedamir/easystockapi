using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Ingredients.Queries;
using SmartRestaurant.Domain.Entities;
using System.Linq;

namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public class FilterIngredientsByName : IIngredientFilterStrategy
    {
        public PagedResultBase<Ingredient> FetchData(DbSet<Ingredient> ingredients, GetIngredientsListQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return ingredients
                       .Where(ingredients => ingredients.Names.Contains(searchKey))
                       .OrderBy(product => product.Names)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return ingredients
                       .Where(ingredients => ingredients.Names.Contains(searchKey))
                       .OrderByDescending(product => product.Names)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return ingredients
                       .Where(ingredients => ingredients.Names.Contains(searchKey))
                       .OrderBy(product => product.Names)
                       .GetPaged(request.Page, request.PageSize);
            }
        }
    }
}
