using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Images.Queries
{
    public class GetImagesByEntityIdQuery : IRequest<IEnumerable<string>>
    {
        public string EntityId { get; set; }
        public string EntityName { get; set; }
    }

    public class GetImagesByEntityIdQueryValidator : AbstractValidator<GetImagesByEntityIdQuery>
    {
        private readonly string uploadImagesEntities =
            $"{UploadImagesEntities.FoodBusiness}" +
            $" | {UploadImagesEntities.Zone}" +
            $" | {UploadImagesEntities.Table}" +
            $" | {UploadImagesEntities.Menu}" +
            $" | {UploadImagesEntities.SubSection}";

        public GetImagesByEntityIdQueryValidator()
        {
            RuleFor(v => v.EntityId).NotEmpty().NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'EntityId' must be a valid GUID");

            RuleFor(v => v.EntityName).NotEmpty().Must(ValidatorHelper.ValidateEntityNameForUploadImages)
                    .WithMessage($"'EntityName' must be have of these values : {uploadImagesEntities}");
        }
    }
}