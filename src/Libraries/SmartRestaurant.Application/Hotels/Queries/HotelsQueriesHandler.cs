using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Hotels.Queries.FilterStrategy;

namespace SmartRestaurant.Application.Hotels.Queries
{
    public class HotelsQueriesHandler :
        IRequestHandler<GetHotelsListQuery, PagedListDto<HotelDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<PagedListDto<HotelDto>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {

            var filter = HotelsStrategies.GetFilterStrategy(request.CurrentFilter);

            var query = filter.FetchData(_context.Hotels, request);

            var data = _mapper.Map<List<HotelDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));


            return new PagedListDto<HotelDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}