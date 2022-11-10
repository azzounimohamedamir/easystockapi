using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.HotelSections.Queries.FilterStrategy
{
    public interface IHotelSectionsFilterStrategy
    {     
        public PagedResultBase<HotelSection> FetchData(DbSet<HotelSection> hotelSections, GetSectionsListByHotelIdQuery request);
    }
}
