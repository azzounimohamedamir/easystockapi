using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusinessClient
{
    public class DeleteFoodBusinessClientCommandValidatorTests
    {
        private readonly DeleteFoodBusinessClientCommandValidator _validator;

        public DeleteFoodBusinessClientCommandValidatorTests()
        {
            _validator = new DeleteFoodBusinessClientCommandValidator();
        }
    
        [Fact]
        public void Given_IdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(x => x.Id, emptyGuid);
        }

    }
}
