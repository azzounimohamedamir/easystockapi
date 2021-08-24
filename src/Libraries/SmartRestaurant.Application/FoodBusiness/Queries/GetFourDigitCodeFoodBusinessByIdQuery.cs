using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetFourDigitCodeFoodBusinessByIdQuery : IRequest<FoodBusinessDto>
    {
        public Guid FoodBusinessId { get; set; }
    }
}