using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinessClientByEmailQuery : IRequest<FoodBusinessClientDto>
    {
        public string Email { get; set; }
    }
}
