using MediatR;
using System;

namespace SmartRestaurant.Application.Restaurants.Commands
{
    public class DeleteRestaurantCommand : IRequest
    {
        public Guid RestaurantId { get; set; }
    }
}
