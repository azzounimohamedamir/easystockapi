using System;
using FluentValidation;
using MediatR;

using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeleteFoodBusinessCommand :IRequest<NoContent>
    {
        public Guid Id { get; set; }
    }

    public class DeleteFoodBusinessCommandValidator : AbstractValidator<DeleteFoodBusinessCommand>
    {
        public DeleteFoodBusinessCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}