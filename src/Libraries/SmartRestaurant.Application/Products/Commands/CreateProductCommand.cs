using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Products.Commands
{
    public class CreateProductCommand : CreateCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public string FoodBusinessId { get; set; }

    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(product => product.Picture)
                .NotEmpty();

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(product => product.EnergeticValue)
               .GreaterThanOrEqualTo(0);

            RuleFor(product => product.Description)
               .MaximumLength(500);

            RuleFor(product => product.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")            
                .When(product => product.FoodBusinessId != null);

        }
    }
}
