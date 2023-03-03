using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.TypeReclamation.Queries
{
    public class GetTypeReclamationListQuery : IPagedListQuery<TypeReclamationDto>
    {
        public string HotelId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}