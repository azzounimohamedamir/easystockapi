using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.Restaurants.Queries
{
    public class GetFoodBusinessByIdQuery : IRequest<FoodBusinessDto>
    {
        public Guid RestaurantId { get; set; }
    }
}