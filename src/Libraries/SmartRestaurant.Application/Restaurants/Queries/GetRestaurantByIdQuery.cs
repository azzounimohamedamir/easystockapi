using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Models.Globalization;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Queries
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
    {
        public Guid RestaurantId { get; set; }
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
