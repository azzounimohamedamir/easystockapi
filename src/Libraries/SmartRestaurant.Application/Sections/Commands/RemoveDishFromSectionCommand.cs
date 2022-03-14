using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class RemoveDishFromSectionCommand : IRequest<NoContent>
    {
        public string SectionId { get; set; }
        public string DishId { get; set; }
    }

    public class RemoveDishFromSectionCommandValidator : AbstractValidator<RemoveDishFromSectionCommand>
    {
        public RemoveDishFromSectionCommandValidator()
        {
            RuleFor(section => section.SectionId)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .NotEqual(Guid.Empty.ToString())
             .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");


            RuleFor(section => section.DishId)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEmpty()
           .NotEqual(Guid.Empty.ToString())
           .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}