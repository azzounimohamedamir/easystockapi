using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Ingredients.Queries
{
    public class GetIngredientByIdQuery : IRequest<IngredientDto>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class GetIngredientByIdQueryValidator : AbstractValidator<GetIngredientByIdQuery>
    {
        public GetIngredientByIdQueryValidator()
        {
            RuleFor(product => product.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}