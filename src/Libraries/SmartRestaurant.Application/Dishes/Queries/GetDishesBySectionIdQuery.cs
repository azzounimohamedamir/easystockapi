using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class GetDishesBySectionIdQuery : IRequest<PagedListDto<DishDto>>
    {
        public Guid SectionId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}