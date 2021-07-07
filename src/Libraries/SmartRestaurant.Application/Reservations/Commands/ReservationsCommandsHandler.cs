using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Reservations.Commands
{
    public class ReservationsCommandsHandler :
        IRequestHandler<CreateReservationCommand, ValidationResult>,
        IRequestHandler<UpdateReservationCommand, ValidationResult>
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

        public async Task<ValidationResult> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            //Validate reservation command data
            var validator = new UpdateReservationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            //Check the existance of the reservation command to be deleted
            var reservation = await _context.Reservations.FindAsync(request.ReservationId).ConfigureAwait(false);
            if (reservation == null)
                throw new NotFoundException(nameof(Reservation), request.ReservationId);

            //Update resarvations command 
            _mapper.Map(request, reservation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}