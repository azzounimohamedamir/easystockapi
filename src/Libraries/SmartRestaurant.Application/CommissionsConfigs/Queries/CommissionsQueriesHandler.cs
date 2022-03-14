using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.commisiones.Queries;
using SmartRestaurant.Application.Commissions.Queries.FilterStrategy;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class CommissionsQueriesHandler : 
        IRequestHandler<GetCommissionConfigsByFoodBusinessIdQuery, CommissionConfigsDto>,
        IRequestHandler<GetCommissionConfigsListQuery, PagedListDto<CommissionConfigsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommissionsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommissionConfigsDto> Handle(GetCommissionConfigsByFoodBusinessIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCommissionConfigsByFoodBusinessIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) 
                throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
               .FirstOrDefaultAsync(fb => fb.FoodBusinessId == Guid.Parse(request.FoodBusinessId))
               .ConfigureAwait(false);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            return _mapper.Map<CommissionConfigsDto>(foodBusiness);
        }


        public async Task<PagedListDto<CommissionConfigsDto>> Handle(GetCommissionConfigsListQuery request,
           CancellationToken cancellationToken)
        {
            var validator = new GetCommissionConfigsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = CommissionStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.FoodBusinesses, request);

            var data = _mapper.Map<List<CommissionConfigsDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<CommissionConfigsDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}