using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries
{
    public class GetClientFideliteListQuery : IRequest<PagedListDto<ClientFideliteDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetClientFideliteListQueryValidator : AbstractValidator<GetClientFideliteListQuery>
    {
        public GetClientFideliteListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}