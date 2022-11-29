using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Orders.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class OrdersQueriesHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>,
        IRequestHandler<GetOrdersListQuery, PagedListDto<OrderDto>>,
        IRequestHandler<GetOrdersListByDinnerOrClientQuery, PagedListDto<OrderDto>>,
        IRequestHandler<GetLastOrderByTableIDQuery, OrderDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public OrdersQueriesHandler(IApplicationDbContext context, IUserService userService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var order = await _context.Orders.AsNoTracking()
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .ThenInclude(o=>o.ComboBoxContentTranslation)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);
                       
            var foodBusiness = await _context.FoodBusinesses.FindAsync(order.FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            orderDto.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(order.CreatedBy));

            return orderDto;
        }

        public async Task<PagedListDto<OrderDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrdersListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = OrderStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Orders, request);

            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<OrderDto>>(queryData);

            foreach (var order in data)
            {
                order.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(order.TotalToPay, foodBusiness.DefaultCurrency);
                order.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(queryData.Find(o => o.OrderId.ToString() == order.OrderId).CreatedBy));
            }
            return new PagedListDto<OrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
        public async Task<PagedListDto<OrderDto>> Handle(GetOrdersListByDinnerOrClientQuery request, CancellationToken cancellationToken)
        {
            var dinerId = _userService.GetUserId();
            var validator = new GetOrdersListByDinnerOrClientQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = OrderStrategies.GetFilterStrategy2(request.CurrentFilter);
            var query = filter.FetchDataOfDinnerOrClient(_context.Orders, request);

            var queryData = await query.Data.Where(a=>a.CreatedBy== dinerId).ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<OrderDto>>(queryData);

            foreach (var order in data)
            {
                order.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(order.TotalToPay, foodBusiness.DefaultCurrency);
                order.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(queryData.Find(o => o.OrderId.ToString() == order.OrderId).CreatedBy));
            }
            return new PagedListDto<OrderDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
        public async Task<OrderDto> Handle(GetLastOrderByTableIDQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetLastOrderByTableIDValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var orders = await _context.Orders.AsNoTracking()
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .ThenInclude(o => o.ComboBoxContentTranslation)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .Where(o => o.OccupiedTables.Select(t => t.TableId).Contains(request.TableId))
                .OrderByDescending(o=>o.CreatedAt)
                .Take(1)
                .AsNoTracking()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
            if (orders == null || orders.Count==0)
                throw new NotFoundException(nameof(Order), request.TableId);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(orders[0].FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.TableId);

            var orderDto = _mapper.Map<OrderDto>(orders[0]);
            orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);
            orderDto.CreatedBy = _mapper.Map<ApplicationUserDto>(await _userManager.FindByIdAsync(orders[0].CreatedBy));
            return orderDto;
        }
    }
}