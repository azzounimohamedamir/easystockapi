using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

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