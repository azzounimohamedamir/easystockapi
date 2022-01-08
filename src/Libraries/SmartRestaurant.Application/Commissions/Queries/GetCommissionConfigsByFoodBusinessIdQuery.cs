using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.commisiones.Queries
{
    public class GetCommissionConfigsByFoodBusinessIdQuery : IRequest<CommissionConfigsDto>
    {
        public string FoodBusinessId { get; set; }
    }

    public class GetCommissionConfigsByFoodBusinessIdQueryValidator : AbstractValidator<GetCommissionConfigsByFoodBusinessIdQuery>
    {
        public GetCommissionConfigsByFoodBusinessIdQueryValidator()
        {
            RuleFor(commision => commision.FoodBusinessId)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }  
}