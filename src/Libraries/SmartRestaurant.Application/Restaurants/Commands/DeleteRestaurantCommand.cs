using FluentValidation;
using MediatR;
using System;

namespace SmartRestaurant.Application.Restaurants.Commands
{
    public class DeleteRestaurantCommand : IRequest
    {
        public Guid RestaurantId { get; set; }
    }

    public class DeleteRestaurantCommandValidator : AbstractValidator<DeleteRestaurantCommand>
    {
        public DeleteRestaurantCommandValidator()
        {
            RuleFor(v => v.RestaurantId)
                .NotNull();
        }
    }
}
