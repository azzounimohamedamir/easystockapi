using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinessClientByManagerIdQuery : IRequest<FoodBusinessClientDto>
    {
        public string FoodBusinessClientManagerId { get; set; }
    }
}
