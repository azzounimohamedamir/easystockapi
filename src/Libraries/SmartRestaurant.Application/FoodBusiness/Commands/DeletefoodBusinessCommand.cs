using System;
using FluentValidation;
using MediatR;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeletefoodBusinessCommand : IRequest
    {
        public Guid RestaurantId { get; set; }
    }

    public class DeleteFoodBusinessCommandValidator : AbstractValidator<DeletefoodBusinessCommand>
    {
        public DeleteFoodBusinessCommandValidator()
        {
            RuleFor(v => v.RestaurantId)
                .NotNull()
                .NotEmpty();
        }
    }
}
