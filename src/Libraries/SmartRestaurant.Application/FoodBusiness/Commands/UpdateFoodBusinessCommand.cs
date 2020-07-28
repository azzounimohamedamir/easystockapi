using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class UpdateFoodBusinessCommand : SRCommand
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
        public bool IsHandicapFreindly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
        public string RestaurantAdministratorId { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
    }

    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateFoodBusinessCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(v => v.CmdId)
                .NotNull();

            RuleFor(v => v.NameEnglish)
                .MaximumLength(200)
                .NotEmpty()
                .When(n => n.NameFrench == String.Empty && n.NameArabic == String.Empty && n.NameChinese == String.Empty && n.NameRussian == String.Empty && n.NameTurkish == String.Empty);

        }
    }
}
