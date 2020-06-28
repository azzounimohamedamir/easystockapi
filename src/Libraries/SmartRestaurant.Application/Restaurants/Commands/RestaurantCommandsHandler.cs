using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Commands
{
    public class RestaurantCommandHandler :
    IRequestHandler<CreateRestaurantCommand, Guid>,
    IRequestHandler<UpdateRestaurantCommand, Guid>,
    IRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantCommandHandler(IApplicationDbContext context, IMapper mapper)
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

        public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.RestaurantId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId);
            }

            _context.Restaurants.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.RestaurantId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId);
            }

            //entity = _mapper.Map<Restaurant>(request);
            //_context.Restaurants.Add(entity);
            entity.UpdateRestaurantInfo(request.NameArabic, request.NameFrench, request.NameEnglish, request.Description, request.HasCarParking, request.IsHandicapFreindly, request.AcceptsCreditCards, request.AcceptTakeout, request.Tags, request.Website, request.AverageRating, request.NumberRatings);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.RestaurantId;
        }
    }
}
