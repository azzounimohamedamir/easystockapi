using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class DeleteDishCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class DeleteDishCommandValidator : AbstractValidator<DeleteDishCommand>
    {
        public DeleteDishCommandValidator()
        {
            RuleFor(product => product.Id)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}