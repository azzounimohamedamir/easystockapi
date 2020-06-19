using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Delete
{
    public class DeleteDishFamilyModelValidation:AbstractValidator<DeleteDishFamilyModel>
    {
        public DeleteDishFamilyModelValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
        }
    }
}
