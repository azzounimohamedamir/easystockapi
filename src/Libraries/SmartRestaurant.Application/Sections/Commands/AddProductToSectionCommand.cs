using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class AddProductToSectionCommand : IRequest<NoContent>
    {
        public string SectionId { get; set; }
        public string ProductId { get; set; }
    }

    public class AddProductToSectionCommandValidator : AbstractValidator<AddProductToSectionCommand>
    {
        public AddProductToSectionCommandValidator()
        {
            RuleFor(section => section.SectionId)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .NotEqual(Guid.Empty.ToString())
             .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");


            RuleFor(section => section.ProductId)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEmpty()
           .NotEqual(Guid.Empty.ToString())
           .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}