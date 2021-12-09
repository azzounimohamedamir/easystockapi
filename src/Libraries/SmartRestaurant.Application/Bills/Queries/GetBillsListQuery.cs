using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Bills.Queries
{
    public class GetBillsListQuery : IRequest<PagedListDto<BillDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string FoodBusinessId { get; set; }
        public DateFilter DateInterval { get; set; }
    }

    public class GetBillsListQueryValidator : AbstractValidator<GetBillsListQuery>
    {
        public GetBillsListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);

            RuleFor(dish => dish.FoodBusinessId)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .NotEqual(Guid.Empty.ToString())
                 .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}