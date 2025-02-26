using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

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