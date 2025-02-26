using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Depenses.Queries
{
    public class GetDepensesListQuery : IRequest<PagedListDto<Depense>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetDepensesListQueryValidator : AbstractValidator<GetDepensesListQuery>
    {
        public GetDepensesListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}