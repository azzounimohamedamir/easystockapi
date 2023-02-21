using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Reclamation.Commands
{
    public class UpdateReclamationCommand : UpdateCommand
    {
        public NamesDto ReclamationDescription { get; set; }
        public IFormFile Picture { get; set; }
    }
    public class UpdateReclamationCommandValidator : AbstractValidator<UpdateReclamationCommand>
    {
        public UpdateReclamationCommandValidator()
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
