using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Commissions.Commands
{
    using static Testing;

    [TestFixture]
    public class SetFoodBusinessCommissionTest : TestBase
    {
        [Test]
        public async Task SetFoodBusinessCommission_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var setFoodBusinessCommissionCommand = new SetFoodBusinessCommissionCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                Value = 25,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusinessCustomer,
            };

            await SendAsync(setFoodBusinessCommissionCommand);
            var fastFoodWithCommissionSet = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            
            fastFoodWithCommissionSet.AcceptsCreditCards.Should().Be(fastFood.AcceptsCreditCards);
            fastFoodWithCommissionSet.AcceptTakeout.Should().Be(fastFood.AcceptTakeout);
            fastFoodWithCommissionSet.Address.City.Should().Be(fastFood.Address.City);
            fastFoodWithCommissionSet.Address.StreetAddress.Should().Be(fastFood.Address.StreetAddress);
            fastFoodWithCommissionSet.Address.Country.Should().Be(fastFood.Address.Country);
            fastFoodWithCommissionSet.Address.GeoPosition.Latitude.Should().Be(fastFood.Address.GeoPosition.Latitude);
            fastFoodWithCommissionSet.Address.GeoPosition.Longitude.Should().Be(fastFood.Address.GeoPosition.Longitude);
            fastFoodWithCommissionSet.Description.Should().Be(fastFood.Description);
            fastFoodWithCommissionSet.HasCarParking.Should().Be(fastFood.HasCarParking);
            fastFoodWithCommissionSet.IsHandicapFriendly.Should().Be(fastFood.IsHandicapFriendly);
            fastFoodWithCommissionSet.Name.Should().Be(fastFood.Name);
            fastFoodWithCommissionSet.OffersTakeout.Should().Be(fastFood.OffersTakeout);
            fastFoodWithCommissionSet.PhoneNumber.CountryCode.Should().Be(fastFood.PhoneNumber.CountryCode);
            fastFoodWithCommissionSet.PhoneNumber.Number.Should().Be(fastFood.PhoneNumber.Number);
            fastFoodWithCommissionSet.Tags.Should().Be(fastFood.Tags);
            fastFoodWithCommissionSet.Email.Should().Be(fastFood.Email);
            fastFoodWithCommissionSet.Website.Should().Be(fastFood.Website);
            fastFoodWithCommissionSet.FoodBusinessAdministratorId.Should().Be(fastFood.FoodBusinessAdministratorId);
            fastFoodWithCommissionSet.DefaultCurrency.Should().Be(fastFood.DefaultCurrency);
            fastFoodWithCommissionSet.IsActivityFrozen.Should().BeFalse();
            fastFoodWithCommissionSet.CommissionConfigs.Value.Should().Be(setFoodBusinessCommissionCommand.Value);
            fastFoodWithCommissionSet.CommissionConfigs.Type.Should().Be(setFoodBusinessCommissionCommand.Type);
            fastFoodWithCommissionSet.CommissionConfigs.WhoPay.Should().Be(setFoodBusinessCommissionCommand.WhoPay);

        }
    }
}
