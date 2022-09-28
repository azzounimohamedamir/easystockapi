using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Hotels.Queries
{
    public class HotelsQueriesHandler :
        IRequestHandler<GetHotelsListQuery, IEnumerable<HotelsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<IEnumerable<HotelsDto>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Hotels.ToArrayAsync(cancellationToken)
                .ConfigureAwait(false);
            return _mapper.Map<IEnumerable<HotelsDto>>(query);
        }
    }
}