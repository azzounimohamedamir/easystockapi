using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class CheckInventaireEquipeQuery : IRequest<CheckInventoryResultDto>
    {
    }

    public class CheckInventaireEquipeQueryValidator : AbstractValidator<CheckInventaireEquipeQuery>
    {
        public CheckInventaireEquipeQueryValidator()
        {
           
        }
    }
}