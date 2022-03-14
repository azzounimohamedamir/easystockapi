using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class DeleteIllnessCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class DeleteIllnessCommandValidator : AbstractValidator<DeleteIllnessCommand>
    {
        public DeleteIllnessCommandValidator()
        {
            RuleFor(illness => illness.Id)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
