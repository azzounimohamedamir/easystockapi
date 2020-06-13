using FluentValidation;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Validations
{
    public class DishModelValidation: AbstractValidator<IDishModel>
    {
        public DishModelValidation()
        {
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.Description)
               .MaximumLength(380)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "380"));

            RuleFor(x => x.RestaurantId)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.RestaurantId));

            RuleFor(x => x.RestaurantId)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.RestaurantId));

            RuleFor(x => x.FamillyId)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.FamillyId));

            RuleFor(x => x.FamillyId)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.FamillyId));

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.FamillyId));
            
            RuleFor(x => x.PreparationTime)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.PreparationTime));

            RuleFor(x => x.PreparationTime)
                .Must(BeAValidTimeSpan)
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.PreparationTime));

            RuleFor(x => x.ServiceTime)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.ServiceTime));

            RuleFor(x => x.ServiceTime)
                .Must(BeAValidTimeSpan)
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishResource.ServiceTime));

        }

        private bool BeAValidTimeSpan(TimeSpan timeSpan)
        {
            if (timeSpan == default(TimeSpan))
                return false;
            return true;
        }
        private bool BeAValidTimeSpan(TimeSpan? timeSpan)
        {
            if (timeSpan == default(TimeSpan))
                return false;
            return true;
        }

    }
}
