using FluentValidation.TestHelper;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Images.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Images.Queries
{
    public class GetImagesByEntityIdQueryTest
    {
        private readonly GetImagesByEntityIdQueryValidator _validator;

        public GetImagesByEntityIdQueryTest()
        {
            _validator = new GetImagesByEntityIdQueryValidator();
        }
        [Fact]
        public void Given_EntityIdIsEmpty_WhenValidating_ShouldError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(query => query.EntityId, empty);
        }

        [Fact]
        public void Given_EntityIdIsEmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = "00000000-0000-0000-0000-000000000000";
            _validator.ShouldHaveValidationErrorFor(query => query.EntityId, emptyGuid);
        }

        [Fact]
        public void Given_EntityIdIsInvalidGuid_WhenValidating_ShouldError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(query => query.EntityId, invalidGuid);
        }

        [Fact]
        public void Given_EntityId_WhenValidating_ShouldBeValidated()
        {
            var validGuid = "3cbf3570-4444-4673-8746-29b7cf568093";
            _validator.ShouldNotHaveValidationErrorFor(query => query.EntityId, validGuid);
        }

        [Fact]
        public void Given_EntityNameIsInvalid_WhenValidating_ShouldError()
        {
            var invalidEntityName = "FoodBusiness_";
            _validator.ShouldHaveValidationErrorFor(query => query.EntityName, invalidEntityName);
        }

        [Fact]
        public void Given_EntityNameIsFoodBusiness_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(query => query.EntityName, UploadImagesEntities.FoodBusiness);
        }

        [Fact]
        public void Given_EntityNameIsZone_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(query => query.EntityName, UploadImagesEntities.Zone);
        }

        [Fact]
        public void Given_EntityNameIsTable_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(query => query.EntityName, UploadImagesEntities.Table);
        }

        [Fact]
        public void Given_EntityNameIsMenu_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(query => query.EntityName, UploadImagesEntities.Menu);
        }

        [Fact]
        public void Given_EntityNameIsSubSection_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(query => query.EntityName, UploadImagesEntities.SubSection);
        }      
    }
}