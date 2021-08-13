using FluentValidation.TestHelper;
using SmartRestaurant.Application.Users.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Users.Queries
{
    public class GetFoodBusinessManagersWithinOrganizationQueryTest
    {
        private readonly GetFoodBusinessManagersWithinOrganizationValidator _validator;

        public GetFoodBusinessManagersWithinOrganizationQueryTest()
        {
            _validator = new GetFoodBusinessManagersWithinOrganizationValidator();
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