using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries
{
    public class GetBAListQuery : IRequest<PagedListDto<Domain.Entities.BonAchats>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetBAListQueryValidator : AbstractValidator<GetBAListQuery>
    {
        public GetBAListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}