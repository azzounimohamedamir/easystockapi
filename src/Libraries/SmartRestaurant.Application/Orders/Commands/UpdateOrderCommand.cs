using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Orders.Commands.Requests;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class UpdateOrderCommand : UpdateCommand
    {
        public List<OrderDishRequest> OrderDishes { get; set; }
        public float MoneyReceived { get; set; }
        public OrderTypes OrderType { get; set; }
    }

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
            RuleFor(o => o.OrderDishes).NotEmpty();
        }
    }
}