using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Illness.Queries
{
    public class GetIllnessesListQuery : IRequest<PagedListDto<IllnessDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
    }
    public class GetIllnessesListQueryValidator : AbstractValidator<GetIllnessesListQuery>
    {
        public GetIllnessesListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}
