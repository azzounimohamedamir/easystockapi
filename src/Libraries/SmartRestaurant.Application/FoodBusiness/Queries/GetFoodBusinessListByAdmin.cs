using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetFoodBusinessListByAdmin : IRequest<List<FoodBusinessDto>>
    {
        public string FoodBusinessAdministratorId { get; set; }
    }
}
