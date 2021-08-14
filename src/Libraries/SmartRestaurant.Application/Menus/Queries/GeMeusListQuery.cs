using System;
using System.Collections.Generic;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetMenusListQuery : IRequest<List<MenuDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}