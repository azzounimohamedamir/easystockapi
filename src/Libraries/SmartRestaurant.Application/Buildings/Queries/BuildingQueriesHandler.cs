using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Buildings.Queries.FilterStrategy;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Buildings.Queries
{
    public class BuildingQueriesHandler :
        IRequestHandler<GetAllBuildingsByHotelId,PagedListDto<BuildingDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BuildingQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public async Task<PagedListDto<BuildingDto>> Handle(GetAllBuildingsByHotelId request, CancellationToken cancellationToken)
        {
            var filter = BuildingStrategies.GetFilterStrategy(request.CurrentFilter);

            var query = filter.FetchData(_context.Buildings, request);

            var data = _mapper.Map<List<BuildingDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));


            return new PagedListDto<BuildingDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);



          
        }
    }
}