using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class GetZonesListQuery : IRequest<IEnumerable<ZoneDto>>
    {
        public Guid FoodBusinessId { get; set; }
    }
}
