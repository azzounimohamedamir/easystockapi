using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.DeviceID.Queries
{
    public class GetDeviceIDByIdQuery : IRequest<DeviceIDDto>
    {
        public string IdentifierDevice { get; set; }
    }
}
