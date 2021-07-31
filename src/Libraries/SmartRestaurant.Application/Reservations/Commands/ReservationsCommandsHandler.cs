using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class ReservationsCommandsHandler :
        IRequestHandler<CreateReservationCommand, Created>,
        IRequestHandler<UpdateReservationCommand, NoContent>,
        IRequestHandler<DeleteReservationCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateReservationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result); 
            var reservation = _mapper.Map<Reservation>(request);
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteReservationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new DeleteReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result); 
            var reservation = await _context.Reservations.FindAsync(request.Id).ConfigureAwait(false);
            if (reservation == null)
                throw new NotFoundException(nameof(Reservation), request.Id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateReservationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new UpdateReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result); 
            var reservation = await _context.Reservations.AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReservationId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (reservation == null)
                throw new NotFoundException(nameof(Reservation), request.Id);
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