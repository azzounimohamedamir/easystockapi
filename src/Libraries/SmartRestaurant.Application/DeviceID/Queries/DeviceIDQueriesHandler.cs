using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.DeviceID.Queries
{
    public class DeviceIDQueriesHandler : IRequestHandler<GetDeviceIDByIdQuery, DeviceIDDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeviceIDQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DeviceIDDto> Handle(GetDeviceIDByIdQuery request, CancellationToken cancellationToken)
        {
           var query = _context.LinkedDevices.FirstOrDefault(d => d.IdentifierDevice == request.IdentifierDevice);
            return _mapper.Map<DeviceIDDto>(query);
        }
    }
}
