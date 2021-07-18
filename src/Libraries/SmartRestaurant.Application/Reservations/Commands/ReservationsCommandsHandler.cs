using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class ReservationsCommandsHandler :
        IRequestHandler<CreateReservationCommand, ValidationResult>,
        IRequestHandler<UpdateReservationCommand, ValidationResult>,
        IRequestHandler<DeleteReservationCommand, ValidationResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CreateReservationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var reservation = _mapper.Map<Reservation>(request);
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
       
        public async Task<ValidationResult> Handle(DeleteReservationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new DeleteReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var reservation = await _context.Reservations.FindAsync(request.CmdId).ConfigureAwait(false);
            if (reservation == null)
                throw new NotFoundException(nameof(Reservation), request.CmdId);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateReservationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new UpdateReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var reservation = await _context.Reservations.AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReservationId == request.CmdId, cancellationToken)
                .ConfigureAwait(false);
            if (reservation == null)
                throw new NotFoundException(nameof(Reservation), request.CmdId);
            var entity = _mapper.Map<Reservation>(request);
            entity.FoodBusinessId = reservation.FoodBusinessId;
            entity.CreatedBy = reservation.CreatedBy;
            entity.CreatedAt = reservation.CreatedAt;
            _context.Reservations.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
    }
}