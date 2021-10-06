using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(product => product.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");           
        }
    }
}
