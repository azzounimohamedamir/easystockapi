using System;
using FluentValidation;
using MediatR;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeletefoodBusinessCommand : IRequest
    {
        public Guid RestaurantId { get; set; }
    }

    public class DeleteRestaurantCommandValidator : AbstractValidator<DeletefoodBusinessCommand>
    {
        public DeleteRestaurantCommandValidator()
        {
            RuleFor(v => v.RestaurantId)
                .NotNull()
                .NotEmpty();
        }
    }
}
