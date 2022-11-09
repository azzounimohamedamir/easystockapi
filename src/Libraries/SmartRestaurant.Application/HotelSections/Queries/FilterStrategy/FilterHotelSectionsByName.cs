using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.HotelSections.Queries.FilterStrategy

{
    public class FilterHotelSectionsByName : IHotelSectionsFilterStrategy
    {
        public PagedResultBase<HotelSection> FetchData(DbSet<HotelSection> hotelSections, GetSectionsListByHotelIdQuery request)
        {
            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;


            return hotelSections
               .Where(Condition(request.HotelId, searchKey, request.language))
               .GetPaged(request.Page, request.PageSize);

        }

        private static Expression<Func<HotelSection, bool>> Condition(string hotelId,  string searchKey, string language)
        {
            switch(language)
            {
                case "ar":
                    if (hotelId == null)
                        return hotelSection => (hotelSection.Names.AR.Contains(searchKey))
                        && hotelSection.HotelId == null;
                    else
                        return hotelSection => (hotelSection.Names.AR.Contains(searchKey)) 
                        && hotelSection.HotelId == Guid.Parse(hotelId);
                case "en":
                    if (hotelId == null)
                        return hotelSection => (hotelSection.Names.EN.Contains(searchKey))
                        && hotelSection.HotelId == null;
                    else
                        return hotelSection => (hotelSection.Names.EN.Contains(searchKey))
                        && hotelSection.HotelId == Guid.Parse(hotelId);
                case "fr":
                    if (hotelId == null)
                        return hotelSection => (hotelSection.Names.FR.Contains(searchKey))
                        && hotelSection.HotelId == null;
                    else
                        return hotelSection => (hotelSection.Names.FR.Contains(searchKey))
                        && hotelSection.HotelId == Guid.Parse(hotelId);
                case "tr":
                    if (hotelId == null)
                        return hotelSection => (hotelSection.Names.TR.Contains(searchKey))
                        && hotelSection.HotelId == null;
                    else
                        return hotelSection => (hotelSection.Names.TR.Contains(searchKey))
                        && hotelSection.HotelId == Guid.Parse(hotelId);
                case "ru":
                    if (hotelId == null)
                        return hotelSection => (hotelSection.Names.RU.Contains(searchKey))
                        && hotelSection.HotelId == null;
                    else
                        return hotelSection => (hotelSection.Names.RU.Contains(searchKey))
                        && hotelSection.HotelId == Guid.Parse(hotelId);
                default:
                    if (hotelId == null)
                        return hotelSection => (hotelSection.Names.EN.Contains(searchKey))
                        && hotelSection.HotelId == null;
                    else
                        return hotelSection => (hotelSection.Names.EN.Contains(searchKey))
                        && hotelSection.HotelId == Guid.Parse(hotelId);

            }
        }

    }
}
