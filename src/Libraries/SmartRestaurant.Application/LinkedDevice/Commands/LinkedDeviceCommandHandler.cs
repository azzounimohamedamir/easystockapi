using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.LinkedDevice.Commands
{
    public class LinkedDeviceCommandHandler :
        IRequestHandler<CreateLinkedDeviceCommand, Created>,
        IRequestHandler<UpdateLinkedDeviceCommand, NoContent>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public LinkedDeviceCommandHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
        }

        public async Task<Created> Handle(CreateLinkedDeviceCommand request, CancellationToken cancellationToken)
        {
            var userID = _userService.GetUserId();
            if (userID == null)
                throw new NotFoundException(nameof(Domain.Entities.LinkedDevice), request.Id);

            var validator = new CreateLinkedDeviceCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var LinkedDevice = await _context.LinkedDevices.AsNoTracking()
                .FirstOrDefaultAsync(t => t.IdentifierDevice == request.IdentifierDevice, cancellationToken)
                .ConfigureAwait(false);
            if (LinkedDevice != null)
            {
                LinkedDevice.FoodBusinessId = request.FoodBusinessId;
                _context.LinkedDevices.Update(LinkedDevice);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var foodBusiness = await _context.LinkedDevices.AsNoTracking()
                    .FirstOrDefaultAsync(t => t.FoodBusinessId == request.FoodBusinessId, cancellationToken)
                    .ConfigureAwait(false);
                if (foodBusiness != null)
                {
                    foodBusiness.IdentifierDevice = request.IdentifierDevice;
                    _context.LinkedDevices.Update(foodBusiness);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    var deviceId = _mapper.Map<Domain.Entities.LinkedDevice>(request);
                    _context.LinkedDevices.Add(deviceId);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }

            return default;
        }

        public async Task<NoContent> Handle(UpdateLinkedDeviceCommand request, CancellationToken cancellationToken)
        {
            var foodBusinessManagerId = _userService.GetUserId();
            if (foodBusinessManagerId == string.Empty || string.IsNullOrWhiteSpace(foodBusinessManagerId))
                throw new InvalidOperationException("FoodBusinessManager Id shouldn't be null or  empty");

            var validator = new UpdateLinkedDeviceommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var linkedDevice = await _context.LinkedDevices.AsNoTracking()
                .FirstOrDefaultAsync(t => t.IdentifierDevice == request.IdentifierDevice, cancellationToken)
                .ConfigureAwait(false);
            if (linkedDevice == null)
                throw new NotFoundException(nameof(Domain.Entities.LinkedDevice), request.Id);
            _mapper.Map(request, linkedDevice);
            _context.LinkedDevices.Update(linkedDevice);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}