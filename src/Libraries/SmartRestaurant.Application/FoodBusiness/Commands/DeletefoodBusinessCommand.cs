using System;
using FluentValidation;
using MediatR;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeletefoodBusinessCommand : IRequest
    {
        public Guid FoodBusinessId { get; set; }
    }

    public class DeleteFoodBusinessCommandValidator : AbstractValidator<DeletefoodBusinessCommand>
    {
        public DeleteFoodBusinessCommandValidator()
        {
            RuleFor(v => v.FoodBusinessId)
                .NotNull()
                .NotEmpty();
        }
    }
}
