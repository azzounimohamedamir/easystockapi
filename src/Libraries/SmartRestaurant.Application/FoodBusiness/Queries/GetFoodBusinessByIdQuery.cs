using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetFoodBusinessByIdQuery : IRequest<FoodBusinessDto>
    {
        public Guid FoodBusinessId { get; set; }
    }
}