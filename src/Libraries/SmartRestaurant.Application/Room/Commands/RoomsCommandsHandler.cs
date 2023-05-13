using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Rooms.Commands
{
    public class RoomsCommandsHandler :
        IRequestHandler<CreateRoomCommand, Created>,
        IRequestHandler<UpdateRoomCommand, NoContent>,
        IRequestHandler<DeleteRoomCommand, NoContent>,
        IRequestHandler<UpdateRoomStatusCommand, Room>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle( CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRoomCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var isExistRoomInSameBuildingWithSameRoomNumber = _context.Rooms.Where(c => c.BuildingId == request.BuildingId && c.RoomNumber == request.RoomNumber).FirstOrDefault();
            if (isExistRoomInSameBuildingWithSameRoomNumber != null)
                throw new ConflictException("Sorry, Room Number "+request.RoomNumber+" is Already Exist in Building , Choose a Different Room Number ");

            var roomtoAdd = _mapper.Map<Room>(request);
            _context.Rooms.Add(roomtoAdd);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteRoomCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var room = await _context.Rooms.FindAsync(request.Id).ConfigureAwait(false);
            if (room == null)
                throw new NotFoundException(nameof(Room), request.Id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoomCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var room = await _context.Rooms.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (room == null)
                throw new NotFoundException(nameof(Room), request.Id);
            if(room.IsBooked==true && request.isBooked==false)
            {
                var CheckinToUpdateRoomState = _context.CheckIns.Where(c => c.RoomId == room.Id).FirstOrDefault();
                CheckinToUpdateRoomState.RoomId = Guid.Empty;
                CheckinToUpdateRoomState.RoomNumber = 0;
                _context.CheckIns.Update(CheckinToUpdateRoomState);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            var entity = _mapper.Map<Room>(request);
            _context.Rooms.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        public async Task<Room> Handle(UpdateRoomStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoomStatusCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var room = await _context.Rooms
                
                .FirstOrDefaultAsync(o => o.Id == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (room == null)
                throw new NotFoundException(nameof(Order), request.Id);


            room.Cleaned = true;
            room.IsBooked = false;
            room.DateCheckout = DateTime.Now;
            _mapper.Map(request, room);
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return room;
        }
    }
}