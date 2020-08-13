using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class CreateFoodBusinessCommand : SmartRestaurantCommand
    {

        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public string NameTurkish { get; set; }
        public string NameChinese { get; set; }
        public string NameRussian { get; set; }
        public string NameSpanish { get; set; }
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
        public string Tags { get; set; }
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
            RuleFor(v => v.NameEnglish)
                .MaximumLength(200)
                .Must(CheckName);
            RuleFor(v => v.FoodBusinessAdministratorId).NotEmpty();
        }

        private bool CheckName(CreateFoodBusinessCommand createFoodBusiness, string nameEnglish)
        {
            return !string.IsNullOrEmpty(nameEnglish) && !string.IsNullOrWhiteSpace(nameEnglish) || string.IsNullOrEmpty(nameEnglish) &&
                (!string.IsNullOrEmpty(createFoodBusiness.NameFrench) && !string.IsNullOrWhiteSpace(createFoodBusiness.NameFrench)
                 || !string.IsNullOrEmpty(createFoodBusiness.NameArabic) && !string.IsNullOrWhiteSpace(createFoodBusiness.NameArabic)
                 || !string.IsNullOrEmpty(createFoodBusiness.NameSpanish) && !string.IsNullOrWhiteSpace(createFoodBusiness.NameSpanish)
                 || !string.IsNullOrEmpty(createFoodBusiness.NameTurkish) && !string.IsNullOrWhiteSpace(createFoodBusiness.NameTurkish)
                 || !string.IsNullOrEmpty(createFoodBusiness.NameChinese) && !string.IsNullOrWhiteSpace(createFoodBusiness.NameChinese)
                );
        }
    }
}
