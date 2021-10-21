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
using SmartRestaurant.Application.Orders.Queries.Responses;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class GetOrdersQueriesHandler : IRequestHandler<GetOrderByd, OrderResponse>,
        IRequestHandler<GetOrdersByFoodBusinessIdQuery, PagedListDto<OrderResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(GetOrderByd request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Where(o => o.OrderId == request.OrderId).Include(o => o.OrderDishes)
                .ThenInclude(o => o.OrderDishIngredients).FirstOrDefaultAsync(cancellationToken);
            if (order == null) throw new NotFoundException(nameof(Order), request.OrderId);
            var dto = _mapper.Map<OrderResponse>(order);
            await MapPrice(new List<OrderResponse> {dto}, new List<Order> {order}, order.FoodBusinessId);
            return dto;
        }

        public async Task<PagedListDto<OrderResponse>> Handle(GetOrdersByFoodBusinessIdQuery request,
            CancellationToken cancellationToken)
        {
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var result = _context.Orders.Where(o => o.FoodBusinessId == request.FoodBusinessId)
                .Include(o => o.OrderDishes).ThenInclude(o => o.OrderDishIngredients)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<OrderResponse>>(
                await result.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
            await MapPrice(data, result.Data.ToList(), request.FoodBusinessId);
            var pagedResult = new PagedListDto<OrderResponse>(result.CurrentPage, result.PageCount, result.PageSize,
                result.RowCount, data);
            return pagedResult;
        }

        private async Task MapPrice(List<OrderResponse> data, List<Order> result, Guid foodBusinessId)
        {
            //var currency = await GetFoodBusinessDefaultCurrency(foodBusinessId);
            //foreach (var orderResponse in data) orderResponse.ExchangeCurrency = _mapper.Map<CurrencyDto>(currency);
        }

        //private async Task<CurrencyDto> GetFoodBusinessDefaultCurrency(Guid foodBusinessId)
        //{
        //    //var foodBusiness = await _context.FoodBusinesses
        //    //    .FirstOrDefaultAsync(d => d.FoodBusinessId == foodBusinessId);
        //    //var currency = await _context.Currencies.FindAsync(foodBusiness.DefaultCurrencyId);
        //    //if (currency != null) return _mapper.Map<CurrencyDto>(currency);

        //    return new CurrencyDto
        //    {
        //        Code = "DZD",
        //        Name = "Algerian Dinar",
        //        Symbol = "DZD"
        //    };
        //}
    }
}