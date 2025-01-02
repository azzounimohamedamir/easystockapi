using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Queries
{
    public class GetDefaultConfigQuery : IRequest<Domain.Entities.DefaultConfigLog>
    { 
    }

    public class GetDefaultConfigQueryValidator : AbstractValidator<GetDefaultConfigQuery>
    {
        public GetDefaultConfigQueryValidator()
        {
          
        }
    }
}