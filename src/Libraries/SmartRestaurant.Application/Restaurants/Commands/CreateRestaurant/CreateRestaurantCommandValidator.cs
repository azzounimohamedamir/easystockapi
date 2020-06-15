using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(v => v.NameEnglish)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
