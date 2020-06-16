using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Handlers
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Restaurant>(request);
            _context.Restaurants.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.RestaurantId;
        }
    }

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.Id);
            }

            _context.Restaurants.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRestaurantCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.RestaurantId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId);
            }

            entity = _mapper.Map<Restaurant>(request);
            _context.Restaurants.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.RestaurantId;
        }
    }
}
