using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(product => product.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");           
        }
    }
}
