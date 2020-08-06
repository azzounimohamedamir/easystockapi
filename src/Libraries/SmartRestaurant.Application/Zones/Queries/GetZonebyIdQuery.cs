using System;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class GetZoneByIdQuery :IRequest<ZoneDto>
    {
        public Guid ZoneId { get; set; }
    }
}
