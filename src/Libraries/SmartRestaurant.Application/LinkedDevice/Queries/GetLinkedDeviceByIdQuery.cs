using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.LinkedDevice.Queries
{
    public class GetLinkedDeviceByIdQuery : IRequest<LinkedDeviceDto>
    {
        public string IdentifierDevice { get; set; }
    }
}