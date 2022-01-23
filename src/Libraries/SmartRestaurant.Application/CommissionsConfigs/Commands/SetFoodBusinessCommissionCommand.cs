using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.commisiones.Commands
{
    public class SetFoodBusinessCommissionCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string FoodBusinessId { get; set; }
        public float Value { get; set; }
        public CommissionType Type { get; set; }
        public WhoPayCommission WhoPay { get; set; }
    }

    public class SetFoodBusinessCommissionCommandValidator : AbstractValidator<SetFoodBusinessCommissionCommand>
    {
        public SetFoodBusinessCommissionCommandValidator()
        {
            RuleFor(commision => commision.FoodBusinessId)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(commision => commision.Value)
                .GreaterThanOrEqualTo(0);

            RuleFor(commision => commision.Type)
                .IsInEnum();

            RuleFor(commision => commision.WhoPay)
               .IsInEnum();
        }
    }  
}