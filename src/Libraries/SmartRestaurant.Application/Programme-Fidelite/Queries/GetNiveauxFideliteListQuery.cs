using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries
{
    public class GetNiveauxFideliteListQuery : IRequest<PagedListDto<NiveauFideliteDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetNiveauxFideliteListQueryValidator : AbstractValidator<GetNiveauxFideliteListQuery>
    {
        public GetNiveauxFideliteListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}