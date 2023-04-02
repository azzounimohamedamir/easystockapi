using System;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Hotels.Commands
{
    public class UpdateHotelRatingCommand : IRequest<HotelDto>
    {

        [JsonIgnore] public string HotelId { get; set; }
        public int Rating { get; set; }
        public string ApplicationUserId { get; internal set; }
    }

    public class UpdateHotelRatingCommandValidator : AbstractValidator<UpdateHotelRatingCommand>
    {
        public UpdateHotelRatingCommandValidator()
        {
            RuleFor(hotelUserRating => hotelUserRating.HotelId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");


            RuleFor(hotelUserRating => hotelUserRating.Rating)
            .NotEmpty().InclusiveBetween(0,5);
        }
    }
}