using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class ToggleFoodBusinessFreezingStatusCommand : IRequest<NoContent>
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