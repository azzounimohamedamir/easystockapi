using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class AddIngredientToIllnessCommand : IRequest<NoContent>
    {
        public string IllnessId { get; set; }
        public string IngredientId { get; set; }
    }

    public class AddIngredientToIllnessCommandValidator : AbstractValidator<AddIngredientToIllnessCommand>
    {
        public AddIngredientToIllnessCommandValidator()
        {
            RuleFor(illness => illness.IllnessId)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .NotEqual(Guid.Empty.ToString())
             .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");


            RuleFor(illness => illness.IngredientId)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEmpty()
           .NotEqual(Guid.Empty.ToString())
           .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}
