using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

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

    public class UpdateFoodBusinessCommandValidator : AbstractValidator<UpdateFoodBusinessCommand>
    {
        public UpdateFoodBusinessCommandValidator()
        {
            RuleFor(v => v.CmdId)
                .NotNull();

            RuleFor(v => v.NameEnglish)
                .MaximumLength(200)
                .Must(CheckName);

        }

        private bool CheckName(UpdateFoodBusinessCommand arg1, string arg2)
        {
            return !string.IsNullOrEmpty(arg2) && !string.IsNullOrWhiteSpace(arg2) || string.IsNullOrEmpty(arg2) &&
                (!string.IsNullOrEmpty(arg1.NameFrench) && !string.IsNullOrWhiteSpace(arg1.NameFrench)
                 || !string.IsNullOrEmpty(arg1.NameArabic) && !string.IsNullOrWhiteSpace(arg1.NameArabic)
                 || !string.IsNullOrEmpty(arg1.NameSpanish) && !string.IsNullOrWhiteSpace(arg1.NameSpanish)
                 || !string.IsNullOrEmpty(arg1.NameTurkish) && !string.IsNullOrWhiteSpace(arg1.NameTurkish)
                 || !string.IsNullOrEmpty(arg1.NameChinese) && !string.IsNullOrWhiteSpace(arg1.NameChinese)
                );
        }

        

        
    }
}
