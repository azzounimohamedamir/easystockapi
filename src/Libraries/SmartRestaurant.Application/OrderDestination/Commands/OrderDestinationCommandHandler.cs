using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.OrderDestination.Commands
{
    public class OrderDestinationCommandsHandler :
        IRequestHandler<CreateOrderDestinationCommand, Created>,
        IRequestHandler<UpdateOrderDestinationCommand, NoContent>,
        IRequestHandler<DeleteOrderDestinationCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderDestinationCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateOrderDestinationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderDestinationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var orderdestinaation = _mapper.Map<Domain.Entities.OrderDestination>(request);
            _context.OrderDestinations.Add(orderdestinaation);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteOrderDestinationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrderDestinationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var orderdestination = await _context.OrderDestinations.FindAsync(request.Id).ConfigureAwait(false);
            if (orderdestination == null)
                throw new NotFoundException(nameof(Domain.Entities.OrderDestination), request.Id);
            _context.OrderDestinations.Remove(orderdestination);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateOrderDestinationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderDestinationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var orderdestination = await _context.OrderDestinations.AsNoTracking()
                .FirstOrDefaultAsync(s => s.OrderDestinationId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (orderdestination == null)
                throw new NotFoundException(nameof(Domain.Entities.OrderDestination), request.Id);
            var entity = _mapper.Map<Domain.Entities.OrderDestination>(request);
            _context.OrderDestinations.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }


    }
}