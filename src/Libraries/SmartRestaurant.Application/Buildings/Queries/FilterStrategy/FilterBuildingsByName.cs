using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Buildings.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Buildings.Queries.FilterStrategy
{
    public class FilterBuildingByName : IBuildingFilterStrategy
    {
        public PagedResultBase<Building> FetchData(DbSet<Building> buildings, GetAllBuildingsByHotelId request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;


            return buildings
               .Where(Condition(searchKey))
               .Where(b => b.HotelId == request.HotelId)
               .GetPaged(request.Page, request.PageSize);

        }

        private static Expression<Func<Building, bool>> Condition(string searchKey)
        {

            return building => building.Name.Contains(searchKey);
        }
    }
}
