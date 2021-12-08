using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Bills.Commands
{
    public class UpdateBillCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public int Discount { get; set; }
        public List<BillDishCommandDto> Dishes { get; set; }
        public List<BillProductCommandDto> Products { get; set; }
    }

    public class UpdateBillCommandValidator : AbstractValidator<UpdateBillCommand>
    {
        public UpdateBillCommandValidator()
        {
            RuleFor(product => product.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100);

            RuleForEach(x => x.Products)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Ingredient' must not be empty")
                .SetValidator(new BillProductCommandDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Products) == false);

            RuleForEach(x => x.Dishes)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Dish' must not be empty")
                .SetValidator(new BillDishCommandDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Dishes) == false);
        }
    }
}