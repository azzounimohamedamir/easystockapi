using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Models.Globalization;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Application.Restaurants.Commands
{
    public class UpdateRestaurantCommand : IRequest<Guid>
    {
        public Guid RestaurantId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public AddressDto Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Description { get; set; }
        public float AverageRating { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFreindly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
    }

    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(v => v.NameEnglish)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
