using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Checkins.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Checkins.Commands
{
    public class CheckInCommandsHandler :
        IRequestHandler<CreateCheckInCommand, Created>,
        IRequestHandler<UpdateCheckInAssignRoomCommand, NoContent>,
        IRequestHandler<ActivateCheckinCommand, NoContent>



    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityContext _identityContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public CheckInCommandsHandler(IUserService userService, IApplicationDbContext context, IIdentityContext identityContext,
            IMapper mapper)
        {
            _context = context;
            _identityContext = identityContext;
            _mapper = mapper;
            _userService = userService;
        }



        public async Task<Created> Handle(CreateCheckInCommand request,
            CancellationToken cancellationToken)
        {

            bool isExistDraft= CheckOfAlreadyExistingDraft(request.hotelId);

            if(!isExistDraft)
            {
                var validator = new CreateCheckInCommandValidator();
                var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid) throw new ValidationException(result);
                var checkin = _mapper.Map<Domain.Entities.CheckIn>(request);
                _context.checkIns.Add(checkin);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            

            return default;

        }



        public bool CheckOfAlreadyExistingDraft(Guid hotelid)
        {
            bool isExist = _context.checkIns.Where(a=>a.hotelId==hotelid).Any(checkin => checkin.ClientId == null);
            return isExist;

        }

        public async Task<NoContent> Handle(UpdateCheckInAssignRoomCommand request, CancellationToken cancellationToken)
        {
            var checkin = await _context.checkIns
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (checkin == null)
                throw new NotFoundException(nameof(CheckIn), request.Id);
            var roomtoBook = _context.Rooms.Where(a => a.Id == request.RoomId).FirstOrDefault();
            roomtoBook.IsBooked = true;
            _mapper.Map(request, checkin);
            _context.Rooms.Update(roomtoBook);
            _context.checkIns.Update(checkin);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(ActivateCheckinCommand request, CancellationToken cancellationToken)
        {
            var userconnected = _userService.GetUserId();
            var AppuserInfo=_identityContext.ApplicationUser.Where(user=>user.Id==userconnected).FirstOrDefault();
            var checkin = await _context.checkIns
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (checkin == null)
                throw new NotFoundException(nameof(CheckIn), request.Id);

            checkin.ClientId = AppuserInfo.Id;
            checkin.FullName = AppuserInfo.FullName;
            checkin.Email = AppuserInfo.Email;
            checkin.PhoneNumber = AppuserInfo.PhoneNumber;
            checkin.IsActivate = true;

            if(checkin.RoomNumber != 0)
            {
                var roomtoBook = _context.Rooms.Where(a => a.Id == checkin.RoomId).FirstOrDefault();

                roomtoBook.IsBooked = true;
                roomtoBook.ClientEmail = AppuserInfo.Email;
                roomtoBook.ClientId = Guid.Parse(AppuserInfo.Id);
                _context.Rooms.Update(roomtoBook);
            }
            
            _context.checkIns.Update(checkin);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }



    }
}