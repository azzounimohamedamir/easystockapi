using System;
using System.Collections.Generic;
using MediatR;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class GetImagesByFoodBusinessIdQuery : IRequest<IEnumerable<Byte[]>>
    {
        public Guid FoodBusinessId { get; set; }
    }
}
