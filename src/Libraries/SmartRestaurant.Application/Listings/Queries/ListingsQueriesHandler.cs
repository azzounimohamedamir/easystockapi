using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace SmartRestaurant.Application.Listings.Queries
{
    public class ListingsQueriesHandler: IRequestHandler<GetListingsByHotelIdQuery, PagedListDto<ListingDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ListingsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<ListingDto>> Handle(GetListingsByHotelIdQuery request,
            CancellationToken cancellationToken)
        {
            var validator = new GetListingsListByHotelIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = _context.Listings.
                Include(l=>l.ListingDetails).Where(s => s.HotelId == Guid.Parse(request.HotelId))
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<ListingDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<ListingDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }
    }
}
