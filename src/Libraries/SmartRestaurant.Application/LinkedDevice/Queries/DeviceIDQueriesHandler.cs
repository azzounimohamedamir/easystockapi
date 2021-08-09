using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.LinkedDevice.Queries
{
    public class DeviceIDQueriesHandler : IRequestHandler<GetDeviceIDByIdQuery, LinkedDeviceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeviceIDQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LinkedDeviceDto> Handle(GetDeviceIDByIdQuery request, CancellationToken cancellationToken)
        {
           var query = _context.LinkedDevices.FirstOrDefault(d => d.IdentifierDevice == request.IdentifierDevice);
            if (query==null) throw new NotFoundException(nameof(Domain.Entities.LinkedDevice), request.IdentifierDevice);
            return _mapper.Map<LinkedDeviceDto>(query);
        }
    }
}
