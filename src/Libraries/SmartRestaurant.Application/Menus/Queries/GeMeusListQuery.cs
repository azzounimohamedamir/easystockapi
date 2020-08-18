using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetMenusListQuery : IRequest<PagedListDto<MenuDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}
