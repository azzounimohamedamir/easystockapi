using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class RemoveProductFromSubSectionCommand : IRequest<NoContent>
    {
        public string SubSectionId { get; set; }
        public string ProductId { get; set; }
    }

    public class RemoveProductFromSubSectionCommandValidator : AbstractValidator<RemoveProductFromSubSectionCommand>
    {
        public RemoveProductFromSubSectionCommandValidator()
        {
            RuleFor(section => section.SubSectionId)
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