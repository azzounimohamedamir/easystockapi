using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.ServiceTechniqueDestination.Queries
{
    public class GetAllServiceTechniquesDestinationByHotelIdQuery : IPagedListQuery<ServiceTechniqueDto>
    {
        public string HotelId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}