using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;
using System;


namespace SmartRestaurant.Application.ListingDetails.Commands
{
    public class UpdateListingDetailCommand : UpdateCommand
    {
        public Names Names { get; set; }
        public IFormFile Picture { get; set; }
        public Guid ListingId { get; set; }
    }

    public class UpdateListingDetailCommandValidator : AbstractValidator<UpdateListingDetailCommand>
    {
        public UpdateListingDetailCommandValidator()
        {
            RuleFor(m => m.ListingId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID");
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
