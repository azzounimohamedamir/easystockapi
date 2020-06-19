using FluentValidation;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Foods.Validations;

namespace SmartRestaurant.Application.Foods.Commands.Update
{
    public class UpdateFoodCommandValidation : AbstractValidator<IFoodModelCommand>
    {
        public UpdateFoodCommandValidation()
        {
            RuleFor(x => x.FoodModel).SetValidator(new FoodModelValidation());
            RuleFor(x => x.Nutrition).SetValidator(new NutritionModelValidation());
            //RuleForEach(x => x.Compositions).SetValidator(new FoodCompositionModelValidation());
        }
    }
}
