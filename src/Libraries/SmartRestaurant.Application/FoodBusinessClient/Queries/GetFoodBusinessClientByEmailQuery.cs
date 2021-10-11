using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class GetFoodBusinessClientByEmailQuery : IRequest<FoodBusinessClientDto>
    {
        public string Email { get; set; }
    }
    public class GetFoodBusinessClientByEmailQueryValidator : AbstractValidator<GetFoodBusinessClientByEmailQuery>
    {
        public GetFoodBusinessClientByEmailQueryValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200)
                .Must(ValidatorHelper.ValidateEmail).WithMessage("'{PropertyName}: {PropertyValue}' is invalide");
        }
    }
}
