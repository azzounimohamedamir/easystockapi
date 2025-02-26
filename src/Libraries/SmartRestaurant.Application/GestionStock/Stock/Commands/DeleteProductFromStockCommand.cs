using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class DeleteProductFromStockCommand : DeleteCommand
    {
    }

    public class DeleteProductFromStockCommandValidator : AbstractValidator<DeleteProductFromStockCommand>
    {
        public DeleteProductFromStockCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}