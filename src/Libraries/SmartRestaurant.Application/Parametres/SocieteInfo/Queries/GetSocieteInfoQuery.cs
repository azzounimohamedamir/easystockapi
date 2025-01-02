using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Parametres.SocieteInfo.Queries
{
    public class GetSocieteInfoQuery : IRequest<Domain.Entities.SocieteInfo>
    { 
    }

    public class GetSocieteInfoQueryValidator : AbstractValidator<GetSocieteInfoQuery>
    {
        public GetSocieteInfoQueryValidator()
        {
          
        }
    }
}