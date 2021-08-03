using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Interfaces;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.DeviceID.Commands
{
    public class DeviceIDCommandHandler : 
        IRequestHandler<CreateDeviceIDCommand, ValidationResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeviceIDCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ValidationResult> Handle(CreateDeviceIDCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDeviceIDCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var deviceId = _mapper.Map<Domain.Entities.DeviceID>(request);
            _context.DevicesID.Add(deviceId);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
