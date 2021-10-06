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
        public string SubSectionId { get; set; }
        public string SectionId { get; set; }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(product => product.SectionId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
                .When(x => (!String.IsNullOrWhiteSpace(x.SectionId) && String.IsNullOrWhiteSpace(x.SubSectionId)));

            RuleFor(product => product.SubSectionId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
              .When(x => (String.IsNullOrWhiteSpace(x.SectionId) && !String.IsNullOrWhiteSpace(x.SubSectionId)));

            RuleFor(product => new { product.SectionId, product.SubSectionId })
              .Must(x => false).WithMessage("You can not set 'Section Id' and 'SubSection Id' at the same time. you must set one property only")
              .When(x => !String.IsNullOrWhiteSpace(x.SectionId) && !String.IsNullOrWhiteSpace(x.SubSectionId));

            RuleFor(product => new { product.SectionId, product.SubSectionId })
             .Must(x => false).WithMessage("You must set either a 'Section Id' or 'SubSection Id'.")
             .When(x => String.IsNullOrWhiteSpace(x.SectionId) && String.IsNullOrWhiteSpace(x.SubSectionId));

            RuleFor(product => product.Picture)
                .NotEmpty();

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(product => product.EnergeticValue)
               .GreaterThanOrEqualTo(0);

            RuleFor(product => product.Description)
               .MaximumLength(500);
        }
    }
}
