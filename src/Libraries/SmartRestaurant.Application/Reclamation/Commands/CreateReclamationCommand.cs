using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Reclamation.Commands
{
    public class CreateReclamationCommand : CreateCommand
    {
        public string ClientId { get; set; }
        public string RoomId { get; set; }
        public string CheckinId { get; set; }
        public NamesDto ReclamationDescription { get; set; }
        public IFormFile Picture { get; set; }
        public DateTime ? CreatedAt { get; set; }
        public ReclamationStatus Status { get; set; }
    }

    public class CreateReclamationCommandValidator : AbstractValidator<CreateReclamationCommand>
    {
        public CreateReclamationCommandValidator()
        {
            RuleFor(v => v.ReclamationDescription)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull()
              .DependentRules(() =>
              {
                  RuleFor(v => v.ReclamationDescription.AR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.ReclamationDescription.EN)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.ReclamationDescription.FR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.ReclamationDescription.TR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.ReclamationDescription.RU)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotEmpty()
                   .MaximumLength(200);
              });
            RuleFor(l => l.Picture).NotEmpty();

        }
    }
}
