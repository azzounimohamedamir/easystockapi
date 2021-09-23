using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class GetDishesByMenuIdQuery : IRequest<PagedListDto<DishDto>>
    {
        public Guid MenuId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}