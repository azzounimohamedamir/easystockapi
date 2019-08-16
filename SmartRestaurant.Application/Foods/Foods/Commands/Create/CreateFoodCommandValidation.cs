using FluentValidation;
using SmartRestaurant.Application.Foods.Foods.Validations;

namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public class CreateFoodCommandValidation : AbstractValidator<IFoodModelCommand>
    {
        public CreateFoodCommandValidation()
        {
            RuleFor(x => x.FoodModel).SetValidator(new FoodModelValidation());
            RuleFor(x => x.Nutrition).SetValidator(new NutritionModelValidation());
            //RuleForEach(x => x.Compositions).SetValidator(new FoodCompositionModelValidation());
        }
    }
}
