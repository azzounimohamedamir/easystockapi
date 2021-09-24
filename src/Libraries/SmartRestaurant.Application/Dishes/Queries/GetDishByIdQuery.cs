using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class GetDishByIdQuery : IRequest<DishDto>
    {
        public Guid DishId { get; set; }
    }
}