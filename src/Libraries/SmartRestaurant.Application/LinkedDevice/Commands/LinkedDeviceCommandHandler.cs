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
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.LinkedDevice.Commands
{
    public class LinkedDeviceCommandHandler :
        IRequestHandler<CreateLinkedDeviceCommand, Created>
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
        //public async Task<Created> IRequestHandler<CreateDeviceIDCommand, Created>.Handle(CreateDeviceIDCommand request, CancellationToken cancellationToken)
        //{
        //    var userID=_userService.GetUserId();
        //    if (userID==null)
        //    throw new NotFoundException(nameof(DeviceID), request.Id);
        //    var validator = new CreateDeviceIDCommandValidator();
        //    var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
        //    if (!result.IsValid) throw new ValidationException(result);
        //    var deviceId = _mapper.Map<Domain.Entities.LinkedDevice>(request);
        //    _context.LinkedDevices.Add(deviceId);
        //    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        //    return default;
        //}

      public  async Task<Created> Handle(CreateLinkedDeviceCommand request, CancellationToken cancellationToken)
        {

            var userID = _userService.GetUserId();
            if (userID == null)
            throw new NotFoundException(nameof(LinkedDevice), request.Id);

            var validator = new CreateLinkedDeviceCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var deviceId = _mapper.Map<Domain.Entities.LinkedDevice>(request);
            _context.LinkedDevices.Add(deviceId);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
