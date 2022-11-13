using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using SmartRestaurant.Application.HotelSections.Queries.FilterStrategy;


namespace SmartRestaurant.Application.HotelSections.Queries
{
    public class HotelSectionQueriesHandler :
        IRequestHandler<GetSectionsListByHotelIdQuery, PagedListDto<HotelSectionDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelSectionQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<HotelSectionDto>> Handle(GetSectionsListByHotelIdQuery request,
            CancellationToken cancellationToken)
        {
            var validator = new GetSectionsListByHotelIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = HotelSectionsStrategies.GetFilterStrategy(request.CurrentFilter);

            var query = filter.FetchData(_context.HotelSections, request);

            var data = _mapper.Map<List<HotelSectionDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));


            return new PagedListDto<HotelSectionDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}
