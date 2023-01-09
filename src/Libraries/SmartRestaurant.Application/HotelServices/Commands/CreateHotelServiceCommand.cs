using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.HotelServices.Commands
{
    public class CreateHotelServiceCommand : CreateCommand
    {
        public Guid SectionId { get; set; }
        public Names Names { get; set; }
        public string Picture { get; set; }
        public string VideoUrl { get; set; }
        public Guid OrderDestinationId { get; set; }
        public List<CreateServiceParametreDto> Parametres { get; set; }
        public bool isSmartrestaurantMenue { get; set; }
        public string FoodBusinessID { get; set; }
        public string MenuID { get; set; }
        public Names DetailServce { get; set; }
        public Names TitelSeccesResponce { get; set; }
        public Names TitelFailureResponce { get; set; }
    }

    public class CreateHotelServiceCommandValidator : AbstractValidator<CreateHotelServiceCommand>
    {
        public CreateHotelServiceCommandValidator()
        {
            RuleFor(m => m.SectionId).NotEmpty().NotEqual(Guid.Empty).WithMessage("'{PropertyName}' must be a valid GUID");
            RuleFor(v => v.Names).Cascade(CascadeMode.StopOnFirstFailure)
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
            RuleFor(v => v.DetailServce).Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull()
             .DependentRules(() =>
             {
                 RuleFor(v => v.DetailServce.AR)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.DetailServce.EN)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.DetailServce.FR)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.DetailServce.TR)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.DetailServce.RU)
                  .Cascade(CascadeMode.StopOnFirstFailure)
                  .NotEmpty()
                  .MaximumLength(200);
             });
            RuleFor(v => v.TitelSeccesResponce).Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull()
              .DependentRules(() =>
              {
                  RuleFor(v => v.TitelSeccesResponce.AR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.TitelSeccesResponce.EN)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.TitelSeccesResponce.FR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.TitelSeccesResponce.TR)
                     .Cascade(CascadeMode.StopOnFirstFailure)
                     .NotEmpty()
                     .MaximumLength(200);

                  RuleFor(v => v.TitelSeccesResponce.RU)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotEmpty()
                   .MaximumLength(200);
              });
            RuleFor(v => v.TitelFailureResponce).Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull()
             .DependentRules(() =>
             {
                 RuleFor(v => v.TitelFailureResponce.AR)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.TitelFailureResponce.EN)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.TitelFailureResponce.FR)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.TitelFailureResponce.TR)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);

                 RuleFor(v => v.TitelFailureResponce.RU)
                  .Cascade(CascadeMode.StopOnFirstFailure)
                  .NotEmpty()
                  .MaximumLength(200);
             });
        }
    }
}
