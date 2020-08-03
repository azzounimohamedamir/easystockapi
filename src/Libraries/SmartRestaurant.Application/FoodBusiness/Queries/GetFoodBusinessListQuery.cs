using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetFoodBusinessListQuery : IRequest<List<FoodBusinessDto>>
    {
    }
}
