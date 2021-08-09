using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.LinkedDevice.Queries
{
    public class GetDeviceIDByIdQuery : IRequest<LinkedDeviceDto>
    {
        public string IdentifierDevice { get; set; }
    }
}
