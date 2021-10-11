using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Ingredients.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public interface IIngredientFilterStrategy
    {     
        public PagedResultBase<Ingredient> FetchData(DbSet<Ingredient> ingredients, GetIngredientsListQuery request);
    }
}
