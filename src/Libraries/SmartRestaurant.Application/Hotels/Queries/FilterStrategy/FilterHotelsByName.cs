using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Hotels.Queries.FilterStrategy
{
    public class FilterHotelsByName : IHotelsFilterStrategy
    {
        public PagedResultBase<Hotel> FetchData(DbSet<Hotel> hotels, GetHotelsListQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;
            var sortOrder = string.IsNullOrWhiteSpace(request.SortOrder) ? "acs" : request.SortOrder;

            switch (sortOrder)
            {
                case "acs":
                    return hotels
                       .Where(Condition( searchKey))
                       .OrderBy(hotel => hotel.Name)
                       .GetPaged(request.Page, request.PageSize);

                case "desc":
                    return hotels
                       .Where(Condition( searchKey))
                       .OrderByDescending(hotel => hotel.Name)
                       .GetPaged(request.Page, request.PageSize);

                default:
                    return hotels
                       .Where(Condition( searchKey))
                       .OrderBy(hotel => hotel.Name)
                       .GetPaged(request.Page, request.PageSize);
            }
        }

        private static Expression<Func<Hotel, bool>> Condition( string searchKey)
        {
           
                return hotel => hotel.Name.Contains(searchKey) ;
        }

    }
}
