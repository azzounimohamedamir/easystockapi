using System;
using MediatR;

namespace SmartRestaurant.Application.Zones.Commands
{
    public class DeleteZoneCommand : IRequest
    {
        public Guid ZoneId { get; set; }
    }
}
