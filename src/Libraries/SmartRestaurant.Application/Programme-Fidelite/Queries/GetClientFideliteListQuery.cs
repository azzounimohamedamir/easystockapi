using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

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