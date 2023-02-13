using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class UpdateFoodBusinessRatingCommand : IRequest<FoodBusinessDto>
    {

        [JsonIgnore] public string FoodBusinessId { get; set; }
        public int Rating { get; set; }
        public string ApplicationUserId { get; internal set; }
    }

    public class UpdateFoodBusinessRatingCommandValidator : AbstractValidator<UpdateFoodBusinessRatingCommand>
    {
        public UpdateFoodBusinessRatingCommandValidator()
        {
            RuleFor(foodBusinessUserRating => foodBusinessUserRating.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");


            RuleFor(foodBusinessUserRating => foodBusinessUserRating.Rating)
            .NotEmpty().InclusiveBetween(0,5);
        }
    }
}