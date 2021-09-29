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

namespace SmartRestaurant.Application.Sections.Queries
{
    public class SectionsQueriesHandler :
        IRequestHandler<GetSectionsListQuery, PagedListDto<SectionDto>>,
        IRequestHandler<GetSectionByIdQuery, SectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<SectionDto>> Handle(GetSectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Sections.Where(s => s.MenuId == request.MenuId)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<SectionDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<SectionDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<SectionDto> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSectionByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.Sections.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if(section == null)
                throw new NotFoundException(nameof(Section), request.Id);

            return _mapper.Map<SectionDto>(section);
        }
    }
}