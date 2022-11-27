using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.HotelSections.Commands
{
    public class DeleteHotelSectionCommand: IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class DeleteHotelSectionCommandValidator : AbstractValidator<DeleteHotelSectionCommand>
    {
        public DeleteHotelSectionCommandValidator()
        {
            RuleFor(section => section.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
