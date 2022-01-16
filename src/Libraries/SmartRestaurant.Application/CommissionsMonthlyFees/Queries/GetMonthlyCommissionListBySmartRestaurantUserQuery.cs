using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;

namespace SmartRestaurant.Application.CommissionsMonthlyFees.Queries
{
    public class GetMonthlyCommissionListBySmartRestaurantUserQuery : IRequest<PagedListDto<MonthlyCommissionDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string CurrentFilter { get; set; }
    }

    public class GetMonthlyCommissionListBySmartRestaurantUserQueryValidator : AbstractValidator<GetMonthlyCommissionListBySmartRestaurantUserQuery>
    {
        public GetMonthlyCommissionListBySmartRestaurantUserQueryValidator()
        {
            RuleFor(x => x.PageSize)              
                .LessThanOrEqualTo(100);

            RuleFor(x => x.SearchKey)
                .MaximumLength(200);
        }
    }
}
