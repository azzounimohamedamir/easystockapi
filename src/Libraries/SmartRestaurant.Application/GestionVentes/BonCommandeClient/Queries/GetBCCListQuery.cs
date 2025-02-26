using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionVentes.BonCommandeClient.Queries
{
    public class GetBCCListQuery : IRequest<PagedListDto<BonCommandeClientDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetBCCListQueryValidator : AbstractValidator<GetBCCListQuery>
    {
        public GetBCCListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}