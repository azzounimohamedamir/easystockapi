using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Orders.Commands.Requests;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class CreateOrderCommand : CreateCommand
    {
        public List<OrderDishRequest> OrderDishes { get; set; }
        public float MoneyReceived { get; set; }
        public OrderTypes OrderType { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.OrderDishes).NotEmpty();
            RuleFor(m => m.FoodBusinessId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}