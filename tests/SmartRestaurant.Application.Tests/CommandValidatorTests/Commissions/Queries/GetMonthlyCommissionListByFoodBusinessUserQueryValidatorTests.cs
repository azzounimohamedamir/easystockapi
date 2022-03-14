using FluentValidation.TestHelper;
using SmartRestaurant.Application.CommissionsMonthlyFees.Queries;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Commissions.Queries
{
    public class GetMonthlyCommissionListByFoodBusinessUserQueryValidatorTests
    {
        private readonly GetMonthlyCommissionListByFoodBusinessUserQueryValidator _validator;

        public GetMonthlyCommissionListByFoodBusinessUserQueryValidatorTests()
        {
            _validator = new GetMonthlyCommissionListByFoodBusinessUserQueryValidator();
        }

        [Fact]
        public void Given_PageSizeExceedMax_WhenValidating_ShouldGetAnError()
        {
            int exceedMax = 101;
            _validator.ShouldHaveValidationErrorFor(x => x.PageSize, exceedMax);
        }

        [Fact]
        public void Given_FoodBusinessIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, _null);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, empty);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, emptyGuid);
        }

        [Fact]
        public void Given_FoodBusinessIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessId, validEntry);
        }
    }
}
