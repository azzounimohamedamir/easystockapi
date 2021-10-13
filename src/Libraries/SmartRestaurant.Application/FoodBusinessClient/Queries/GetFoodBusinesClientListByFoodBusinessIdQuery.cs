using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinesClientListByFoodBusinessIdQuery : IRequest<IEnumerable<FoodBusinessClientDto>>
    {
        public Guid FoodBusinessId { get; set; }
    }
}
