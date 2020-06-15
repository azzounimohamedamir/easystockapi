using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Models.Globalization;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Queries
{
    public class GetRestaurantsListQuery : IRequest<List<RestaurantDto>>
    {
    }

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
            List<Restaurant> entities =  await _context.Restaurants.ToListAsync();
            return  _mapper.Map<List<RestaurantDto>>(entities);
        }
    }
}
