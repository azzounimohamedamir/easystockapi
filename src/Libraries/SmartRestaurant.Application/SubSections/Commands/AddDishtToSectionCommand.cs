using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class AddDishToSubSectionCommand : IRequest<NoContent>
    {
        public string SubSectionId { get; set; }
        public string DishId { get; set; }
    }

    public class AddDishToSubSectionCommandValidator : AbstractValidator<AddDishToSubSectionCommand>
    {
        public AddDishToSubSectionCommandValidator()
        {
            RuleFor(section => section.SubSectionId)
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