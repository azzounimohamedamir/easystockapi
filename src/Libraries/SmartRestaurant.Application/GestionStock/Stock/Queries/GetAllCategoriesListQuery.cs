using System;
using System.Collections;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class GetCategorieQuery : IRequest<CategoryDto>
    {

    }

    public class GetCategorieQueryValidator : AbstractValidator<GetCategorieQuery>
    {
        public GetCategorieQueryValidator()
        {
            
        }
    }
}