using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetMenuByIdQuery  :IRequest<MenuDto>
    {
        public Guid MenuId { get; set; }
    }
}
