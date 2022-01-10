using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.commisiones.Queries
{
    public class GetMonthlyCommissionListByFoodBusinessUserQuery : IRequest<PagedListDto<MonthlyCommissionDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string FoodBusinessId { get; set; }
    }

    public class GetMonthlyCommissionListByFoodBusinessUserQueryValidator : AbstractValidator<GetMonthlyCommissionListByFoodBusinessUserQuery>
    {
        public GetMonthlyCommissionListByFoodBusinessUserQueryValidator()
        {
            RuleFor(x => x.PageSize)              
                .LessThanOrEqualTo(100);

            RuleFor(x => x.FoodBusinessId)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .NotEqual(Guid.Empty.ToString())
                 .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}
