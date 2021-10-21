using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class OrdersCommandsHandlers : IRequestHandler<CreateOrderCommand, Created>,
        IRequestHandler<UpdateOrderCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrdersCommandsHandlers(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var order = _mapper.Map<Order>(request);
            CalculateTotalPrice(order);
            await Pay(order);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var order = await _context.Orders.AsNoTracking().Include(o => o.OrderDishes)
                .ThenInclude(o => o.OrderDishIngredients).FirstOrDefaultAsync(o => o.OrderId == request.Id,
                    cancellationToken);
            var entity = _mapper.Map<Order>(request);
            entity.FoodBusinessId = order.FoodBusinessId;
            CalculateTotalPrice(entity);
            await Pay(entity);
            await ReplaceOrder(cancellationToken, order, entity);
            return default;
        }

        private async Task Pay(Order order)
        {
            if (order.MoneyReceived > order.TotalToPay)
                order.MoneyReturned = order.MoneyReceived - order.TotalToPay;
            else
                throw new MoneyNotSufficientException(order.TotalToPay, order.MoneyReceived,
                    await GetFoodBusinessDefaultCurrency(order.FoodBusinessId));
        }

        private async Task<string> GetFoodBusinessDefaultCurrency(Guid foodBusinessId)
        {
            //var foodBusiness = await _context.FoodBusinesses
            //    .FirstOrDefaultAsync(d => d.FoodBusinessId == foodBusinessId);
            //var currency = await _context.Currencies.FindAsync(foodBusiness.DefaultCurrencyId);
            //return currency != null ? currency.Symbol : "DZD";

            return "DZD";
        }

        private async Task ReplaceOrder(CancellationToken cancellationToken, Order old, Order @new)
        {
            await RemoveExistingOrder(old, cancellationToken);
            await CreateOrder(@new, cancellationToken);
        }

        private async Task CreateOrder(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task RemoveExistingOrder(Order order, CancellationToken cancellationToken)
        {
            var orderDishes = order.OrderDishes;
            if (orderDishes.Count > 0)
                foreach (var orderDish in orderDishes)
                {
                    foreach (var orderDishIngredient in orderDish.OrderDishIngredients)
                        _context.OrderDishIngredients.Remove(orderDishIngredient);

                    _context.OrderDishes.Remove(orderDish);
                }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private static void CalculateTotalPrice(Order order)
        {
            foreach (var dish in order.OrderDishes)
            {
                order.TotalToPay += dish.PriceValue;
                foreach (var dishIngredient in dish.OrderDishIngredients.Where(dishIngredient =>
                    dishIngredient.Steps > 0))
                    order.TotalToPay += dishIngredient.Steps * dishIngredient.PriceValuePerStep;
            }
        }
    }
}