using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.HotelSections.Commands
{
    public class UpdateHotelSectionCommand: IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string hotelSetionId { get; set; }
        public NamesDto Names { get; set; }
        public IFormFile Picture { get; set; }

        public string HotelId { get; set; }
    }

    public class UpdateHotelSectionCommandValidator : AbstractValidator<UpdateHotelSectionCommand>
    {
        public UpdateHotelSectionCommandValidator()
        {
            RuleFor(section => section.hotelSetionId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(section => section.Picture)
                .NotEmpty();

            RuleFor(v => v.Names)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .DependentRules(() => {
                    RuleFor(v => v.Names.AR)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(v => v.Names.EN)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(v => v.Names.FR)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(v => v.Names.TR)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty()
                       .MaximumLength(200);

                    RuleFor(v => v.Names.RU)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);
                });
        }
    }

}
