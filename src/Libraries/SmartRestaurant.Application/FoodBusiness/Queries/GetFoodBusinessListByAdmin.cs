using System.Collections.Generic;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Restaurants.Queries
{
    public class GetFoodBusinessListByAdmin : IRequest<List<FoodBusinessDto>>
    {
        public string RestaurantAdministratorId { get; set; }
    }
}
