using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class GetAllSubSectionsListQuery : IPagedListQuery<SubSectionDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}