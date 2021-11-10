using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Orders.Queries.Responses;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetOrdersQueriesHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>,
        IRequestHandler<GetOrdersByFoodBusinessIdQuery, PagedListDto<OrderResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var order = await _context.Orders.AsNoTracking()
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Specifications)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Ingredients)
                .Include(o => o.Dishes)
                .ThenInclude(o => o.Supplements)
                .Include(o => o.Products)
                .Include(o => o.OccupiedTables)
                .FirstOrDefaultAsync(o => o.OrderId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (order == null)
                throw new NotFoundException(nameof(Order), request.Id);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(order.FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(orderDto.TotalToPay, foodBusiness.DefaultCurrency);

            return orderDto;
        }

        public async Task<PagedListDto<OrderResponse>> Handle(GetOrdersByFoodBusinessIdQuery request,
            CancellationToken cancellationToken)
        {
            return default;
        }
    }
}