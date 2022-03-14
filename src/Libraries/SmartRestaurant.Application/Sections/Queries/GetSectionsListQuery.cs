using System;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Sections.Queries
{
    public class GetSectionsListQuery : IPagedListQuery<SectionDto>
    {
        public Guid MenuId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}