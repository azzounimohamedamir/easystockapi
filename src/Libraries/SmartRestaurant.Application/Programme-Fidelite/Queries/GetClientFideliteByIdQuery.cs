using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;

namespace SmartRestaurant.Application.ProgrammeFidelite.Queries
{
    public class GetClientFideliteByIdQuery : IRequest<ClientFideliteDto>
    {
        public Guid Id { get; set; }

    }

    public class GetClientFideliteByIdQueryValidator : AbstractValidator<GetClientFideliteByIdQuery>
    {
        public GetClientFideliteByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty();
        }
    }
}