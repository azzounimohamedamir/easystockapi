using MediatR;

namespace SmartRestaurant.Application.Restaurants.Commands
{
    public class DeleteRestaurantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
