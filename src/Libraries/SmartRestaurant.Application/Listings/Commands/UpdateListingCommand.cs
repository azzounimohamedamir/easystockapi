using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;
using System;


namespace SmartRestaurant.Application.Listings.Commands
{
    public class UpdateListingCommand:UpdateCommand
    {
        public Names Names { get; set; }
        public bool WithImage { get; set; }
        public Guid ListingId { get; set; }
        public Guid HotelId { get; set; }
    }

    public class UpdateListingCommandValidator : AbstractValidator<UpdateListingCommand>
    {
        public UpdateListingCommandValidator()
        {

            RuleFor(v => v.Names)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull()
           .DependentRules(() =>
           {
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

            RuleFor(l => l.HotelId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(l => l.ListingId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID"); 

        }
    }
}
