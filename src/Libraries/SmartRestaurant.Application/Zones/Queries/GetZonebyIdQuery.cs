using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class GetZoneByIdQuery : IRequest<ZoneDto>
    {
        public Guid ZoneId { get; set; }
    }
}
