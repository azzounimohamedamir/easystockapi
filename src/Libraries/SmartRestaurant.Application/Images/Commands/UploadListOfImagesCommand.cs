using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Images.Commands
{
    public class UploadListOfImagesCommand : IRequest<Created>
    {
        public string EntityId { get; set; }
        public string EntityName { get; set; }
        public List<IFormFile> Images { get; set; }
    }


    public class UploadListOfImagesCommandValidator : AbstractValidator<UploadListOfImagesCommand>
    {
        private readonly string uploadImagesEntities = 
            $"{UploadImagesEntities.FoodBusiness}" +
            $" | {UploadImagesEntities.Zone}" +
            $" | {UploadImagesEntities.Table}" +
            $" | {UploadImagesEntities.Menu}" +
            $" | {UploadImagesEntities.SubSection}";

        public UploadListOfImagesCommandValidator()
        {
            RuleFor(v => v.EntityId).NotEmpty().NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'EntityId' must be a valid GUID");

            RuleFor(v => v.EntityName).NotEmpty().Must(ValidatorHelper.ValidateEntityNameForUploadImages)
                    .WithMessage($"'EntityName' must be have of these values : {uploadImagesEntities}");

            RuleFor(v => v.Images).NotEmpty();
            RuleForEach(v => v.Images).ChildRules(image => image.RuleFor(x => x).NotEmpty());
        }
    }
}