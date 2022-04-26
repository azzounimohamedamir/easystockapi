using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class AddSeatOrderToTableOrderCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] 
        public string Id { get; set; }
        public List<OrderDishCommandDto> Dishes { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public string TableId { get; set; }
        public int ChairNumber { get; set; }
    }

    public class AddSeatOrderToTableOrderCommandValidator : AbstractValidator<AddSeatOrderToTableOrderCommand>
    {
        public AddSeatOrderToTableOrderCommandValidator()
        {
            RuleFor(m => m.Id)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .NotEqual(Guid.Empty.ToString())
             .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(x => x.Dishes)
                 .Must(x => false).WithMessage("Order can not be empty, please select at least a dish or product")
                 .When(x => ChecksHelper.IsEmptyList(x.Dishes) == true && ChecksHelper.IsEmptyList(x.Products) == true);
         
            RuleForEach(x => x.Products)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Products' must not be empty")
                .SetValidator(new OrderProductDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Products) == false);

            RuleForEach(x => x.Dishes)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Dish' must not be empty")
                .SetValidator(new OrderDishCommandDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Dishes) == false);

            RuleFor(m => m.TableId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString())
            .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(x => x.ChairNumber)
                .GreaterThan(0);
        }
    }
}
