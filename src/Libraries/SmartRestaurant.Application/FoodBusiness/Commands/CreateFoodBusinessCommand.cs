using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class CreateFoodBusinessCommand : SmartRestaurantCommand
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public int NumberRatings { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFriendly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public List<string> Tags { get; set; }
        public string Website { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public FoodBusinessCategory FoodBusinessCategory { get; set; }
    }


    public class CreateFoodBusinessCommandValidator : AbstractValidator<CreateFoodBusinessCommand>
    {
        public CreateFoodBusinessCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200).NotEmpty();
            RuleFor(v => v.FoodBusinessAdministratorId).NotEmpty();
        }
    }
}