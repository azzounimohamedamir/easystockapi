using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class BillsQueriesHandler : 
        IRequestHandler<GetBillsListQuery, PagedListDto<BillDto>>,
        IRequestHandler<GetBillByIdQuery, BillDto>
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
            var totalRevenue = 0.0 ;
            var validator = new GetBillsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = BillStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Orders, request);
            var data = _mapper.Map<List<BillDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
            totalRevenue = data.Where(a => a.Status == Domain.Enums.OrderStatuses.Billed).Select(a => a.TotalToPay).Sum();
            data.ForEach(data =>
            {
                data.TotalRevenue = totalRevenue;
            });
            return new PagedListDto<BillDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<BillDto> Handle(GetBillByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBillByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var order = await _context.Orders.AsNoTracking()
                .Include(o => o.Dishes)
                .Include(o => o.Products)
                .Include(o => o.FoodBusiness)
                .Include(o => o.FoodBusinessClient)
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            return _mapper.Map<BillDto>(order);
        }
    }
}