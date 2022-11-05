using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Hotels.Queries.FilterStrategy
{
    public interface IHotelsFilterStrategy
    {     
        public PagedResultBase<Hotel> FetchData(DbSet<Hotel> hotels, GetHotelsListQuery request);
    }
}
