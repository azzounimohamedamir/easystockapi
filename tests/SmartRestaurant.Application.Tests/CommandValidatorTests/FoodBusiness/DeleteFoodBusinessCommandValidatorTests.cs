using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
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
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.CmdId, emptyGuid);
        }
    }
}