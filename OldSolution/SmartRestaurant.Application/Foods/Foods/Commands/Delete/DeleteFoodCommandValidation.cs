using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Commands.Delete
{
    public class DeleteFoodCommandValidation:AbstractValidator<DeleteFoodModel>
    {
        public DeleteFoodCommandValidation()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
        }
    }
}
