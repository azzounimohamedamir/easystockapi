using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Tables.Queries
{
    public class TablesQueriesHandler :IRequestHandler<GetTablesListQuery, IEnumerable<TableDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TablesQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TableDto>> Handle(GetTablesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Tables.Where(x => x.ZoneId == request.ZoneId).ToArrayAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<TableDto>>(query);
        }
    }
}
