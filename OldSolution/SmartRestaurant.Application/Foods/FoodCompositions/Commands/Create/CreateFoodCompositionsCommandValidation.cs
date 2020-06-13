using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.Quantity;
using SmartRestaurant.Resources.Commun.Unit;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Create
{
    public class CreateFoodCompositionsCommandValidation : AbstractValidator<ICreateFoodCompositionModel>
    {
        public CreateFoodCompositionsCommandValidation()
        {
            
        }
    }
}
