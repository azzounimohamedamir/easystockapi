using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Menus.Queries.FilterStrategy
{
    public interface IMenuFilterStrategy
    {     
        public PagedResultBase<Menu> FetchData(DbSet<Menu> menus, GetMenusListQuery request);
    }
}
