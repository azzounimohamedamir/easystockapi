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

namespace SmartRestaurant.Application.ServiceTechniqueDestination.Queries
{
    public class ServiceTechniqueQueriesHandler :
        IRequestHandler<GetAllServiceTechniquesDestinationByHotelIdQuery, PagedListDto<ServiceTechniqueDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceTechniqueQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<ServiceTechniqueDto>> Handle(GetAllServiceTechniquesDestinationByHotelIdQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.ServiceTechniques.OrderBy(s => s.Names.EN)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<ServiceTechniqueDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<ServiceTechniqueDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }


    }
}