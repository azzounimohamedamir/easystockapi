using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.CommissionsMonthlyFees.Queries.FilterStrategy;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Queries
{
    public class CommissionsMonthlyFeesQueriesHandler :
        IRequestHandler<GetMonthlyCommissionListByFoodBusinessUserQuery, PagedListDto<MonthlyCommissionDto>>,
        IRequestHandler<GetMonthlyCommissionListBySmartRestaurantUserQuery, PagedListDto<MonthlyCommissionDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityContext _identityContext;

        public CommissionsMonthlyFeesQueriesHandler(IApplicationDbContext context, IMapper mapper, IIdentityContext identityContext)
        {
            _context = context;
            _mapper = mapper;
            _identityContext = identityContext;
        }

        public async Task<PagedListDto<MonthlyCommissionDto>> Handle(GetMonthlyCommissionListByFoodBusinessUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetMonthlyCommissionListByFoodBusinessUserQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
                throw new ValidationException(result);

            var query =  _context.MonthlyCommission
                .Where(x => x.FoodBusinessId == Guid.Parse(request.FoodBusinessId))
                .Include(x => x.FoodBusiness)
                .OrderBy(x => x.Status)
                .ThenByDescending(x => x.Month)
                .GetPaged(request.Page, request.PageSize);

            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<MonthlyCommissionDto>>(queryData);

            return new PagedListDto<MonthlyCommissionDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<PagedListDto<MonthlyCommissionDto>> Handle(GetMonthlyCommissionListBySmartRestaurantUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetMonthlyCommissionListBySmartRestaurantUserQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
                throw new ValidationException(result);

            var filter = CommissionsMonthlyFeesStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context, _identityContext, request);

            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<MonthlyCommissionDto>>(queryData);

            return new PagedListDto<MonthlyCommissionDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}