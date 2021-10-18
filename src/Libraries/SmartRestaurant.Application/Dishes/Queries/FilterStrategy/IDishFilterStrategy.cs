using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Dishes.Queries.FilterStrategy
{
    public interface IDishFilterStrategy
    {     
        public PagedResultBase<Dish> FetchData(DbSet<Dish> Dishes, GetDishesListQuery request);
    }
}
