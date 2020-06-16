using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Queries;
using SmartRestaurant.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Handlers
{
    public class GetRestaurantsListQueryHandler : IRequestHandler<GetRestaurantsListQuery, List<RestaurantDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RestaurantDto>> Handle(GetRestaurantsListQuery request, CancellationToken cancellationToken)
        {
            List<Restaurant> entities = await _context.Restaurants.ToListAsync();
            return _mapper.Map<List<RestaurantDto>>(entities);
        }
    }

    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.RestaurantId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId);
            }
            return _mapper.Map<RestaurantDto>(entity);
        }
    }
}
