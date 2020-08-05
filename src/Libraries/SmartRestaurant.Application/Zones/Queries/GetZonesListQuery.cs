using System;
using System.Collections.Generic;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class GetZonesListQuery: IRequest<IEnumerable<ZoneDto>>
    {
        public Guid FoodBusinessId { get; set; }
    }
}
