using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Images.Commands
{
    public class UploadLogoCommand : CreateCommand
    {
        public string EntityId { get; set; }
        public string EntityName { get; set; }
        public IFormFile logo { get; set; }
    }


    public class UploadLogoCommandValidator : AbstractValidator<UploadLogoCommand>
    {
        private readonly string uploadImagesEntities = 
            $"{UploadImagesEntities.FoodBusiness}" +
            $" | {UploadImagesEntities.Zone}" +
            $" | {UploadImagesEntities.Table}" +
            $" | {UploadImagesEntities.Menu}" +
            $" | {UploadImagesEntities.SubSection}";

        public UploadLogoCommandValidator()
        {
            RuleFor(v => v.EntityId).NotEmpty().NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'EntityId' must be a valid GUID");

            RuleFor(v => v.EntityName).NotEmpty().Must(ValidatorHelper.ValidateEntityNameForUploadImages)
                    .WithMessage($"'EntityName' must be have of these values : {uploadImagesEntities}");

            RuleFor(v => v.logo).NotEmpty();
        }
    }
}