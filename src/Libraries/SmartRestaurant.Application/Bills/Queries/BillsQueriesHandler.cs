using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Bills.Queries;
using SmartRestaurant.Application.Bills.Queries.FilterStrategy;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class BillsQueriesHandler : IRequestHandler<GetBillsListQuery, PagedListDto<BillDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BillsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<BillDto>> Handle(GetBillsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBillsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = BillStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Orders, request);

            var data = _mapper.Map<List<BillDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
            return new PagedListDto<BillDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}