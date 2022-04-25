using FluentValidation.TestHelper;
using SmartRestaurant.Application.Orders.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Orders.Commands
{
    public class AddSeatOrderToTableOrderCommandValidatorTest
    {
        private readonly AddSeatOrderToTableOrderCommandValidator _validator;
        public AddSeatOrderToTableOrderCommandValidatorTest()
        {
            _validator = new AddSeatOrderToTableOrderCommandValidator();
        }
        [Fact]
        public void Given_TableIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.TableId, _null);
        }

        [Fact]
        public void Given_TableIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.TableId, empty);
        }

        [Fact]
        public void Given_TableIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.TableId, emptyGuid);
        }

        [Fact]
        public void Given_TableIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.TableId, invalidGuid);
        }

        [Fact]
        public void Given_TableId_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.TableId, validEntry);
        }




        [Fact]
        public void Given_OrderIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Id, _null);
        }

        [Fact]
        public void Given_OrderIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Id, empty);
        }

        [Fact]
        public void Given_OrderIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.Id, emptyGuid);
        }

        [Fact]
        public void Given_OrderIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.Id, invalidGuid);
        }

        [Fact]
        public void Given_OrderId_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, validEntry);
        }


        [Fact]
        public void Given_ChairNumberIsZiro_WhenValidating_ShouldGetAnError()
        {
            var invalidNumber = 0;
            _validator.ShouldHaveValidationErrorFor(x => x.ChairNumber, invalidNumber);
        }
    }
}
