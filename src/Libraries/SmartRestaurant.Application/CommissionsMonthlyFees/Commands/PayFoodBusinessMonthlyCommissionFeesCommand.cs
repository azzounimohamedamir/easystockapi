using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Commands
{
    public class PayFoodBusinessMonthlyCommissionFeesCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string MonthlyCommissionId { get; set; }
    }

    public class PayFoodBusinessMonthlyCommissionFeesCommandValidator : AbstractValidator<PayFoodBusinessMonthlyCommissionFeesCommand>
    {
        public PayFoodBusinessMonthlyCommissionFeesCommandValidator()
        {
            RuleFor(x => x.MonthlyCommissionId)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}