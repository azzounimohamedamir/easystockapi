using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class UpdateReclamationStatusCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public ReclamationStatus Status { get; set; }
    }

    public class UpdateReclamationStatusCommandValidator : AbstractValidator<UpdateReclamationStatusCommand>
    {
        public UpdateReclamationStatusCommandValidator()
        {
            RuleFor(rec => rec.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(m => m.Status)
                .IsInEnum();

           
        }          
    }
}