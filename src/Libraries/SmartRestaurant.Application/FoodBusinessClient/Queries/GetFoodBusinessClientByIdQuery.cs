using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;


namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinessClientByIdQuery : IRequest<FoodBusinessClientDto>
    {
        public Guid FoodBusinessClientId { get; set; }
    }
}
