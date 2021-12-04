using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class ZoneQueriesHandler :
        IRequestHandler<GetZonesListQuery, IEnumerable<ZoneDto>>,
        IRequestHandler<GetZoneByIdQuery, ZoneDto>,
        IRequestHandler<GetZonesListWithTablesQuery, IEnumerable<ZoneWithTablesDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ZoneQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ZoneDto> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ZoneDto>(await _context.Zones.FindAsync(request.ZoneId).ConfigureAwait(false));
        }

        public async Task<IEnumerable<ZoneDto>> Handle(GetZonesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Zones
                .Where(x => x.FoodBusinessId == request.FoodBusinessId)
                .ToArrayAsync(cancellationToken)
                .ConfigureAwait(false);
            return _mapper.Map<List<ZoneDto>>(query);
        }

        public async Task<IEnumerable<ZoneWithTablesDto>> Handle(GetZonesListWithTablesQuery request, CancellationToken cancellationToken)
        {
            var queryZone = await _context.Zones
                .Where(x => x.FoodBusinessId == request.FoodBusinessId)
                .Include(x=>x.Tables)
                .ToArrayAsync(cancellationToken)
                .ConfigureAwait(false);
            var queryZoneDto = _mapper.Map<List<ZoneWithTablesDto>>(queryZone);
            return queryZoneDto;
        }

    }
}