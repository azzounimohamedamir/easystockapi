using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class ToggleFoodBusinessFreezingStatusCommand : DeleteCommand
    {
        [SwaggerSchema(ReadOnly = true)] public string FoodBusinessId { get; set; }

    }

    public class ToggleFoodBusinessFreezingStatusCommandValidator : AbstractValidator<ToggleFoodBusinessFreezingStatusCommand>
    {
        public ToggleFoodBusinessFreezingStatusCommandValidator()
        {
            RuleFor(x => x.FoodBusinessId)
                          .Cascade(CascadeMode.StopOnFirstFailure)
                          .NotEmpty()
                          .NotEqual(Guid.Empty.ToString())
                          .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}