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
        IRequestHandler<GetHotelsListQuery, PagedListDto<HotelsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<PagedListDto<HotelsDto>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {
            Debug.Write("request " + JsonSerializer.Serialize(request));

            var filter = HotelsStrategies.GetFilterStrategy(request.CurrentFilter);
            Debug.Write("filter " + JsonSerializer.Serialize(filter));

            var query = filter.FetchData(_context.Hotels, request);
            Debug.Write("query " + JsonSerializer.Serialize(query));

            var data = _mapper.Map<List<HotelsDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            Debug.Write("datalist " + JsonSerializer.Serialize(data));

            return new PagedListDto<HotelsDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}