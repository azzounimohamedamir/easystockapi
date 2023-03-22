using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.OrderDestination.Queries
{
    public class OrderDestinationQueriesHandler :
        IRequestHandler<GetAllOrderDestinationListByHotelId, PagedListDto<OrderDestinationDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderDestinationQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<OrderDestinationDto>> Handle(GetAllOrderDestinationListByHotelId request,
            CancellationToken cancellationToken)
        {
            var query = (_context.OrderDestinations.Where(s => s.HotelId == Guid.Parse(request.HotelId)).OrderBy(s => s.Names))
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<OrderDestinationDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<OrderDestinationDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }


    }
}