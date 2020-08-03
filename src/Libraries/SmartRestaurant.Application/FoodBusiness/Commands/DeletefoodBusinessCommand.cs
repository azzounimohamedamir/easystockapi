using FluentValidation;
using MediatR;
using System;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeleteFoodBusinessCommand : IRequest
    {
        public Guid FoodBusinessId { get; set; }
    }

    public class DeleteFoodBusinessCommandValidator : AbstractValidator<DeleteFoodBusinessCommand>
    {
        public DeleteFoodBusinessCommandValidator()
        {
            RuleFor(v => v.FoodBusinessId)
                .NotNull()
                .NotEmpty();
        }
    }
}
