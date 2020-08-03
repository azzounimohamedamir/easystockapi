using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusiness
{
    public class DeleteFoodBusinessCommandValidatorTests
    {
        private readonly DeleteFoodBusinessCommandValidator _validator;

        public DeleteFoodBusinessCommandValidatorTests()
        {
            _validator = new DeleteFoodBusinessCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            Guid EmptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.FoodBusinessId, EmptyGuid);
        }
    }
}