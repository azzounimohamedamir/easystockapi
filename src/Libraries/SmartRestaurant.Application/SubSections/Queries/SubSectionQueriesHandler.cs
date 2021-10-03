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

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class SubSectionsQueriesHandler :
        IRequestHandler<GetSubSectionsListQuery, PagedListDto<SubSectionDto>>,
        IRequestHandler<GetSubSectionByIdQuery, SubSectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubSectionsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<SubSectionDto>> Handle(GetSubSectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.SubSections.Where(s => s.SectionId == request.SectionId)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<SubSectionDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<SubSectionDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<SubSectionDto> Handle(GetSubSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSubSectionByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSections = await _context.SubSections.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if (subSections == null)
                throw new NotFoundException(nameof(SubSection), request.Id);

            return _mapper.Map<SubSectionDto>(subSections);
        }
    }
}