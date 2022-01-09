using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;

namespace SmartRestaurant.Application.commisiones.Queries
{
    public class GetCommissionConfigsListQuery : IRequest<PagedListDto<CommissionConfigsDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
    }

    public class GetCommissionConfigsListQueryValidator : AbstractValidator<GetCommissionConfigsListQuery>
    {
        public GetCommissionConfigsListQueryValidator()
        {
            RuleFor(v => v.PageSize)              
                .LessThanOrEqualTo(100);
        }
    }
}
