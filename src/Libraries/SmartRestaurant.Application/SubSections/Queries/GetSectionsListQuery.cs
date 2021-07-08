using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class GetSubSectionsListQuery : IPagedListQuery<SubSectionDto>
    {
        public Guid SectionId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}