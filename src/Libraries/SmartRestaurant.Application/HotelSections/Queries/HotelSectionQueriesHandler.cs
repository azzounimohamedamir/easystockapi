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
using System;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.HotelSections.Queries
{
    public class HotelSectionQueriesHandler :
        IRequestHandler<GetSectionsListByHotelIdQuery, PagedListDto<HotelSectionDto>>,
        IRequestHandler<GetHotelSectionByIdQuery, HotelSectionDto>
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

        public async Task<HotelSectionDto> Handle(GetHotelSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetHotelSectionByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.HotelSections.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(HotelSection), request.Id);

            return _mapper.Map<HotelSectionDto>(section);
        }
    }
}
