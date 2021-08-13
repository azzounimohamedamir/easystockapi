using FluentValidation.TestHelper;
using SmartRestaurant.Application.Users.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Users.Queries
{
    public class GetFoodBusinessEmployeesQueryTest
    {
        private readonly GetFoodBusinessEmployeesValidator _validator;

        public GetFoodBusinessEmployeesQueryTest()
        {
            _validator = new GetFoodBusinessEmployeesValidator();
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmpty_WhenValidating_ShouldError()
        {
            var empty = "" ;
            _validator.ShouldHaveValidationErrorFor(query => query.FoodBusinessId, empty);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = "00000000-0000-0000-0000-000000000000";
            _validator.ShouldHaveValidationErrorFor(query => query.FoodBusinessId, emptyGuid);
        }

        [Fact]
        public void Given_FoodBusinessIdIsInvalidGuid_WhenValidating_ShouldError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(query => query.FoodBusinessId, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessId_WhenValidating_ShouldBeValidated()
        {
            var validGuid = "3cbf3570-4444-4673-8746-29b7cf568093";
            _validator.ShouldNotHaveValidationErrorFor(query => query.FoodBusinessId, validGuid);
        }


        [Fact]
        public void Given_PageSizeExeedsMaximum_WhenValidating_ShouldError()
        {
            var exeedsMaximum = 101;
            _validator.ShouldHaveValidationErrorFor(query => query.PageSize, exeedsMaximum);
        }

        [Fact]
        public void Given_PageSize_WhenValidating_ShouldBeValidated()
        {
            var pageSize = 100;
            _validator.ShouldNotHaveValidationErrorFor(query => query.PageSize, pageSize);
        }
    }
}