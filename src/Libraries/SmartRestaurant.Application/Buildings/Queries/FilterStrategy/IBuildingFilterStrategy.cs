using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Buildings.Queries.FilterStrategy
{
    public interface IBuildingFilterStrategy
    {     
        public PagedResultBase<Building> FetchData(DbSet<Building> rooms, GetAllBuildingsByHotelId request);
    }
}
