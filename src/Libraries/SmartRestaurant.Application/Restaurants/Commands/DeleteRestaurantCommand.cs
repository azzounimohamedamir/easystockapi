using MediatR;

namespace SmartRestaurant.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
