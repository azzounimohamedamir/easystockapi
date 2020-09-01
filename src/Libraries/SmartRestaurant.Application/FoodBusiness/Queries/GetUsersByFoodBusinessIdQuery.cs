using System;
using MediatR;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetUsersByFoodBusinessIdQuery : IRequest<string[]>
    {
        public Guid FoodBusinessId { get; set; }
    }
}
